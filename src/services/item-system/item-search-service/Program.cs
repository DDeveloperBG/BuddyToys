namespace ItemSearchService
{
    using ItemSearchService.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => ItemSearchServiceHost.Start<Startup>(args);
    }
}
