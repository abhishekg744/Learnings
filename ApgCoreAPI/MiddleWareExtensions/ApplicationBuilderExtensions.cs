using ApgCoreAPI.RabbitMQConsumer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApgCoreAPI.MiddleWareExtensions
{
    public static class ApplicationBuilderExtensions
    {
        public static ConsumerEventBus Listener { get; set; }
        public static IApplicationBuilder UseRabbitListner(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<ConsumerEventBus>();
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();
            Console.WriteLine("started rabbit consume middleware");
            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopped.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            Listener.Consume();
        }

        private static void OnStopping()
        {
            Listener.Disconnect();
        }
    }
}
