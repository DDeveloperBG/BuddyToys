namespace WishlistService
{
    using WishlistService.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => WishlistServiceHost.Start<Startup>(args);
    }
}
