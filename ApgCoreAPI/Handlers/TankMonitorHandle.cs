using ApgCoreAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApgCoreAPI.Handlers
{
    public class TankMonitorHandle : IRequestHandler<TankMonitorHandlerModel, PublishEvent>
    {
        //private readonly type _repository;
        public TankMonitorHandle()
        {
        }
        public async Task<PublishEvent> Handle(TankMonitorHandlerModel request, CancellationToken cancellationToken)
        {
            Console.WriteLine("handeled", request.PublishedData);
            return   await Task.FromResult(request.PublishedData);
        }
    }
}
