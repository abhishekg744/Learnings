using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ApgCoreAPI.Models
{
    public class TankMonitorHandlerModel: IRequest<PublishEvent>
    {
        public PublishEvent PublishedData { get; set; }
    }
}
