namespace PaymentInterface
{
    using PaymentInterface.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => PaymentInterfaceHost.Start<Startup>(args);
    }
}
