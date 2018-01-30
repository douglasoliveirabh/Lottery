using Lottery.Application;
using Lottery.Domain.Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.IoC
{
    public class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ISorteioMegaSena, SorteioMegaSena>();
        }
    }
}
