using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

public static class MiddlewareExtensions
{
    public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Customer.Api",
                Version = "v1",
                Description = "Customer RESTful API"
            });
            c.EnableAnnotations();
        });
        return services;
    }

    public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger(c =>
        {
            c.RouteTemplate = "api-docs/{documentName}/swagger.json";
        });

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/api-docs/v1/swagger.json", "Customer API V1");
            c.RoutePrefix = "api-docs/v1";
        });
        return app;
    }
}
