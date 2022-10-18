namespace ForumService
{
    using ForumService.Infrastructure;

    public class Program
    {
        public static void Main(string[] args)
            => ForumServiceHost.Start<Startup>(args);
    }
}
