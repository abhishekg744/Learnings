using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQEventBus.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQEventBus.Producer
{
    public class ProducerEventBus
    {
        private readonly IRabbitMQConnection _connection;

        public ProducerEventBus(IRabbitMQConnection connection)
        {
            _connection = connection;
        }

        public void PublishTankMonitor(string queueName, TankMonitorProducerEvent publishModel)
        {
            using (var channel = _connection.CreateModel())
            {
                // Queue will only be created if it doesn't exist already.
                // Durable - the queue will survive a broker restart.
                // Exclusive - used by only one connection and the queue will be deleted when that connection closes.
                // Auto-delete - queue that has had at least one consumer is deleted when last consumer unsubscribes.
                // Arguments (optional; used by plugins and broker-specific features like queue length limit, etc)
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var message = JsonConvert.SerializeObject(publishModel);
                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                // non-persistent (1) or persistent (2)
                properties.DeliveryMode = 2;
                channel.ConfirmSelect();
                channel.BasicPublish(exchange: "", routingKey: queueName, mandatory: true,
                    basicProperties: properties, body: body);
                channel.WaitForConfirmsOrDie();
                channel.BasicAcks += (sender, eventArgs) =>
                {
                    Console.WriteLine("Sent to RabbitMQ");
                };
                channel.ConfirmSelect();

            }
        }
    }
}
