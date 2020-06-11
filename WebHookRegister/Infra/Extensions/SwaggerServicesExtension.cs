using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace WebHookRegister.Infra.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerServicesExtension
    {
        /// <summary>
        /// Add swagger documentation service on dependency injection container 
        /// </summary>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo()
                    {
                        Title = GetApplicationName(),
                        Version = description.ApiVersion.ToString()
                    });


                }

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

            });

            return services;
        }

        private static string GetApplicationName()
            => Assembly.GetExecutingAssembly().GetName().Name.Replace(".", " ");

        public static IApplicationBuilder UseVersionedSwagger(this IApplicationBuilder builder, IApiVersionDescriptionProvider versionProvider)
        {
            builder.UseSwagger(o => o.RouteTemplate = "swagger/{documentName}/swagger.json");

            builder.UseSwaggerUI(options =>
            {

                foreach (var description in versionProvider.ApiVersionDescriptions)
                {
                    options.RoutePrefix = "swagger";
                    options.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json", description.GroupName);
                }
            });

            return builder;
        }
    }
}
