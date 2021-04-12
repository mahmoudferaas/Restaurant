using Brightskies.Restaurant.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brightskies.Restaurant.Persistence.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DBConnection")));

            services.AddScoped<IRestaurantDbContext>(provider => provider.GetService<RestaurantDbContext>());

            return services;
        }
    }
}