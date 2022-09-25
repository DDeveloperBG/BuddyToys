namespace Receiver_service.Infrastructure
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.IdentityModel.Tokens;

    public static class ConfigureServiceCollection
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
