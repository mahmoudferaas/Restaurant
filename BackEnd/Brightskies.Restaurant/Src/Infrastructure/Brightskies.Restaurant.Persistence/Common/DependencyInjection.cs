using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brightskies.Restaurant.Persistence.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<_DCDT_>(options => options.UseSqlServer(configuration.GetConnectionString("_DBCS_")));

            return services;
        }
    }
}