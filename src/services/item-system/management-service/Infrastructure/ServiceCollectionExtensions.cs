namespace ManagementService.Infrastructure
{
    using AutoMapper;

    using ManagementService.Data;
    using ManagementService.Services.Category;
    using ManagementService.Services.Data.RequestManager;
    using ManagementService.Services.Item;
    using ManagementService.Services.Mapper;

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
            this IServiceCollection serviceCollection)
        {
            var dbManager = new AppDbManager();
            serviceCollection.AddSingleton<AppDbContext>(_ => dbManager.CreateDbContext());

            var mapperManager = new MapperManager();
            serviceCollection.AddSingleton<IMapper>(_ => mapperManager.GetMapper());

            return serviceCollection;
        }

        public static IServiceCollection AddTransientServices(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IItemService, ItemService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IRequestManager, RequestManager>();

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
