namespace ItemReadService
{
    using ItemReadService.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => ItemReadServiceHost.Start<Startup>(args);
    }
}
