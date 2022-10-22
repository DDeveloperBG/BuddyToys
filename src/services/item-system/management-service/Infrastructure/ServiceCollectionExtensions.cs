namespace ManagementService.Infrastructure
{
    using Cassandra;
    using Cassandra.Mapping;

    using ManagementService.Data;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    public static class ServiceCollectionExtensions
    {
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

        public static IServiceCollection AddSingletonServices(
            this IServiceCollection services)
        {
            var db = AppDbContext.CreateInstance();

            services.AddSingleton<ISession>(_ => db.Session);
            services.AddSingleton<IMapper>(_ => db.Mapper);

            return services;
        }

        public static IServiceCollection AddTransientServices(
            this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }

        public static IServiceCollection AddHealthChecksCustom(
            this IServiceCollection serviceCollection)
        {
            var healthChecks = serviceCollection.AddHealthChecks();

            healthChecks
                .AddElasticsearch(elasticsearchUri: "http://localhost:9200");

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
