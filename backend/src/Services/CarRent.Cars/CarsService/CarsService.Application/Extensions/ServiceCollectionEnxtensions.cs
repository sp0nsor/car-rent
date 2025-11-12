using CarsService.Application.Interfaces.Internal;
using CarsService.Application.Interfaces.Public;
using CarsService.Application.Services.Internal;
using CarsService.Application.Services.Public;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System.Reflection;

namespace CarsService.Application.Extensions
{
    public static class ServiceCollectionEnxtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPostsService, PostsService>();
            services.AddScoped<ICarsService, Services.Public.CarsService>();
            services.AddScoped<IImageService, ImageService>();
        }

        public static void AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation(config =>
            {
                config.EnableFormBindingSourceAutomaticValidation = true;
                config.EnableBodyBindingSourceAutomaticValidation = true;
            });
        }
    }
}
