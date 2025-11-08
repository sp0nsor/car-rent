using CarsService.API.Extensions;
using CarsService.API.Middlewares;
using CarsService.Application.Extensions;
using CarsService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddProblemDetails();

services.AddDataBaseConfig(configuration);
services.AddRepositories();

services.AddMappings();

services.AddApiServices();
services.AddApplicationServices();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
