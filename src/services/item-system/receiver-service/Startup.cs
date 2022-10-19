namespace ReceiverService
{
    using ReceiverService.Infrastructure;
    using Serilog;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
            => this.configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddFirebaseAuth(this.configuration)
                .AddSingletonConfigurations(this.configuration)
                .AddTransientServices()
                .AddHealthChecksCustom()
                .AddControllersCustom()
                .AddDataProtectionCustom();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseSerilogRequestLogging()
                .UseWebService(env)
                .Initialize();
    }
}
