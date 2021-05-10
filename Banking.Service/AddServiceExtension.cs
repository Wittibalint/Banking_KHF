using Banking.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddServiceExtension
    {
        public static IServiceCollection AddServiceManager(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            services.AddTransient<IServiceManager, ServiceManager>();
            return services;
        }
    }
}
