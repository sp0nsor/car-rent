using CarsService.API.Middlewares;

namespace CarsService.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionHandlingMiddleware>();

            services.AddEndpointsApiExplorer();
            services.AddControllers();

            services.AddSwaggerGen();
        }
    }
}
