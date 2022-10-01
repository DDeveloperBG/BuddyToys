namespace ShipmentInterface
{
    using ShipmentInterface.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => ShipmentInterfaceHost.Start<Startup>(args);
    }
}
