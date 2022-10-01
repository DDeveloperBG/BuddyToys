﻿namespace WishlistService.Infrastructure
{
    using Serilog;

    public class WishlistServiceHost
    {
        public static void Start<TStartup>(string[] args = null)
            where TStartup : class
        {
            args ??= Array.Empty<string>();

            var logConnection = Environment.GetEnvironmentVariable("LogConnection");

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Http(logConnection, null)
                .CreateLogger();

            Host
                .CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => webBuilder
                    .UseStartup<TStartup>())
                .Build()
                .Run();
        }
    }
}
