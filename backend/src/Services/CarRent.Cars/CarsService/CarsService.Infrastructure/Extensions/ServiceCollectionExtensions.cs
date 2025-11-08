using CarsService.Infrastructure.Entities;
using CarsService.Infrastructure.Interfaces;
using CarsService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarsService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataBaseConfig(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString(nameof(ApplicationDbContext)));
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<CarEntity>, Repository<CarEntity>>();
            services.AddScoped<IRepository<PostEntity>, Repository<PostEntity>>();
        }
    }
}
