﻿namespace ReceiverService.Infrastructure
{
    using HealthChecks.UI.Client;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebService(
            this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapHealthChecks("/health", new HealthCheckOptions
                    {
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                    });

                    endpoints.MapControllers();
                });

            return app;
        }

        public static IApplicationBuilder Initialize(
            this IApplicationBuilder app)
        {
            //using var serviceScope = app.ApplicationServices.CreateScope();
            //var serviceProvider = serviceScope.ServiceProvider;

            //var db = serviceProvider.GetRequiredService<DbContext>();

            //db.Database.Migrate();

            //var seeders = serviceProvider.GetServices<IDataSeeder>();

            //foreach (var seeder in seeders)
            //{
            //    seeder.SeedData();
            //}

            return app;
        }
    }
}
