using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQEventBus.Event
{
    public class TankMonitorProducerEvent
    {
        public Guid RequestId { get; set; }

        // Entity model parameters to be passed
        public string Name { get; set;}
    }
}
