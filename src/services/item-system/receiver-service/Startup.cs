namespace Receiver_service
{
    using Receiver_service.Infrastructure;
    using Serilog;

    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddFirebaseAuth(this.Configuration)
                .AddHealthChecksCustom()
                .AddControllersCustom();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseSerilogRequestLogging()
                .UseWebService(env)
                .Initialize();
    }
}
