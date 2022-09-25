namespace Receiver_service
{
    using Receiver_service.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => ReceiverServiceHost.Start<Startup>(args);
    }
}
