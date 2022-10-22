namespace ManagementService.Infrastructure
{
    public static class ConfigurationBuilderProvider
    {
        public static IConfigurationRoot Get()
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: true)
                .Build();
    }
}
