namespace ManagementService.Infrastructure
{
    using ManangementService.Data;
    using ManangementService.Data.Common;
    using ManangementService.Data.Common.Repositories;
    using ManangementService.Data.Repositories;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services)
        {
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            return services;
        }

        public static IServiceCollection AddFirebaseAuth(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection
                .AddAuthorization()
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.Authority = configuration["Jwt:Firebase:ValidIssuer"];
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Firebase:ValidIssuer"],
                        ValidAudience = configuration["Jwt:Firebase:ValidAudience"],
                    };
                });

            return serviceCollection;
        }

        public static IServiceCollection AddTransientServices(
            this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }

        public static IServiceCollection AddHealthChecksCustom(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHealthChecks();

            return serviceCollection;
        }

        public static IServiceCollection AddControllersCustom(
           this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers();

            return serviceCollection;
        }
    }
}
