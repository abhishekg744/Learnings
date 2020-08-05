using ApgCoreAPI.Models;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQEventBus;
using RabbitMQEventBus.Common;
using RabbitMQEventBus.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApgCoreAPI.RabbitMQConsumer
{
    public class ConsumerEventBus
    {
        private readonly IRabbitMQConnection _connection;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        //private readonly repository

        public ConsumerEventBus(IRabbitMQConnection connection, IMapper mapper)
        {
            _connection = connection;
           // _mediator = mediator;
            _mapper = mapper;
        }

        public void Consume()
        {
            Console.WriteLine("Consume Start");
            var channel = _connection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.TankMonitorQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += RecievedEvent;
            channel.BasicConsume(queue: EventBusConstants.TankMonitorQueue, autoAck: true, consumer: consumer, noLocal: false, exclusive: false, arguments: null);
        }

        private void RecievedEvent(object sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine("Recieved");
            if (e.RoutingKey == EventBusConstants.TankMonitorQueue)
            {
                var message = Encoding.UTF8.GetString(e.Body.Span);
                var data = JsonConvert.DeserializeObject<TankMonitorProducerEvent>(message);
                Console.WriteLine(data);
                var command = _mapper.Map<PublishEvent>(data);
                Console.WriteLine(data);
                //var result = await _mediator.Send(command);
            }
        }

        public void Disconnect()
        {
            _connection.Dispose();
        }
    }
}