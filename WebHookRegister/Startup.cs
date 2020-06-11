using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;
using WebHookRegister.Infra.Extensions;
using WebHookRegister.Infra.Mappers;
using WebHookRegister.Infra.Repositories;
using WebHookRegister.Infra.Repositories.Context;
using WebHookRegister.Infra.Repositories.Interfaces;
using WebHookRegister.Service;
using WebHookRegister.Service.Interfaces;

namespace WebHookRegister
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddVersioning();
            services.AddSwaggerDocumentation();
            services.AddScoped<ITemplateNotificationRepository, TemplateNotificationRepository>();
            services.AddScoped<ITemplateNotificationService, TemplateNotificationService>();
            services.AddScoped<INotifyService, NotifyService>();

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new WebHookAdministrationProfile());
            });
            services.AddSingleton(x => mappingConfig.CreateMapper());

            services.AddDbContextPool<WebHookContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("WebHook"));
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var dbContext = serviceScope.ServiceProvider.GetRequiredService<WebHookContext>();
                    dbContext.Database.EnsureCreated();
                }
            }

            app.UseVersionedSwagger(provider);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
