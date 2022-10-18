namespace OrderService
{
    using OrderService.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => OrderServiceHost.Start<Startup>(args);
    }
}
