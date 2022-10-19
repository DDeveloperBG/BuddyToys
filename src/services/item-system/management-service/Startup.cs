namespace ManagementService
{
    using ManagementService.Infrastructure;
    using Serilog;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
            => this.configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddFirebaseAuth(this.configuration)
                .AddTransientServices()
                .AddDatabase()
                .AddHealthChecksCustom()
                .AddControllersCustom();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseSerilogRequestLogging()
                .UseWebService(env)
                .Initialize();
    }
}
