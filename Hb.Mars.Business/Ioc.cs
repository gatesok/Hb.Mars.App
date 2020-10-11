using Hb.Mars.Core.Contracts;
using Hb.Mars.Core.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hb.Mars.Business
{
   public class Ioc
    {
        public static ServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IOrder, TurnLeftOrder>();
            services.AddTransient<IOrder, TurnRightOrder>();
            services.AddTransient<IOrder, MoveForwardOrder>();
            services.AddTransient<IRoverPosition, RoverPosition>();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IPlateau, Plateau>();

            return services.BuildServiceProvider();
        }
    }
}
