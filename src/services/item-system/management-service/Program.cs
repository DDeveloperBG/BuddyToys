namespace ManagementService
{
    using ManagementService.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => ManagementServiceHost.Start<Startup>(args);
    }
}
