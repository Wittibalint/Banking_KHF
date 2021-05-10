using Banking.data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddRepositoryExtension
    {
        public static IServiceCollection AddBankingRepository(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            services.AddTransient<IBankingRepository, BankingRepository>();
            return services;
        }
    }
}
