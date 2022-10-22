namespace ManagementService.Infrastructure
{
    using Microsoft.Extensions.Configuration;

    public static class ConfigurationExtensions
    {
        public static string GetDbContactPoint(this IConfiguration configuration)
            => configuration["DB:contactPoint"];

        public static int GetDbPort(this IConfiguration configuration)
            => int.Parse(configuration["DB:port"]);

        public static string GetDbUsername(this IConfiguration configuration)
            => configuration["DB:username"];

        public static string GetDbPassword(this IConfiguration configuration)
            => configuration["DB:password"];

        public static string GetDbKeyspace(this IConfiguration configuration)
            => configuration["DB:keyspace"];
    }
}
