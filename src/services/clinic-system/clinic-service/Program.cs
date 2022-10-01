namespace ClinicService
{
    using ClinicService.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => ClinicServiceHost.Start<Startup>(args);
    }
}
