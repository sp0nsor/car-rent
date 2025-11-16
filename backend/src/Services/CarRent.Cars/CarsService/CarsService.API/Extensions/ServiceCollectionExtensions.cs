using CarsService.API.Middlewares;
using System.Text.Json.Serialization;

namespace CarsService.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<GlobalExceptionHandlingMiddleware>();

            services.AddEndpointsApiExplorer();
            services.AddControllers()
                .AddJsonOptions(o =>
                    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
                );

            services.AddSwaggerGen();
        }
    }
}
