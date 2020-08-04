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
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var message = JsonConvert.SerializeObject(publishModel);
                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
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
