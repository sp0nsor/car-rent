
using CarsService.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarsService.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
        : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var statusCode = ex switch
                {
                    BadRequestExecption => StatusCodes.Status400BadRequest,
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };
                var details = new ProblemDetails
                {
                    Title = statusCode == StatusCodes.Status500InternalServerError ? "Internal Server Error" : "Error",
                    Type = ex.GetType().Name,
                    Status = statusCode,
                    Detail = ex.Message,
                    Instance = context.Request.Path.Value
                };

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                var json = JsonSerializer.Serialize(details);

                await context.Response.WriteAsync(json);
            }
        }
    }
}