namespace ReceiverService
{
    using ReceiverService.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => ReceiverServiceHost.Start<Startup>(args);
    }
}
