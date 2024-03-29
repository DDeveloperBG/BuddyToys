﻿namespace ReceiverService.Infrastructure
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
    using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;

    using ReceiverService.Common;
    using ReceiverService.DTOs;
    using ReceiverService.Services.MessageBus;

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

        public static IServiceCollection AddSingletonConfigurations(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddSingleton<MessageBusConfig>(_
                => new MessageBusConfig
                {
                    ConnectionIP = configuration[ConfigConstants.MessageBus.ConnectionIpKey],
                    Name = configuration[ConfigConstants.MessageBus.NameKey],
                });

            return serviceCollection;
        }

        public static IServiceCollection AddTransientServices(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMessageBusService, RabbitMqService>();

            return serviceCollection;
        }

        public static IServiceCollection AddHealthChecksCustom(
            this IServiceCollection serviceCollection)
        {
            var healthChecks = serviceCollection.AddHealthChecks();

            healthChecks
                .AddRabbitMQ(rabbitConnectionString: "amqp://rabbitmq:rabbitmq@rabbitmq/");

            return serviceCollection;
        }

        public static IServiceCollection AddControllersCustom(
           this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers();

            return serviceCollection;
        }

        public static IServiceCollection AddDataProtectionCustom(
           this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo(@"../.aspnet/receiver-service/DataProtection-Keys"))
                .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration()
                {
                    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256,
                });

            return serviceCollection;
        }
    }
}
