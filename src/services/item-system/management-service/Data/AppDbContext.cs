namespace ManagementService.Data
{
    using Cassandra;
    using Cassandra.Mapping;

    using ManagementService.Data.Models;
    using ManagementService.Infrastructure;

    public class AppDbContext : Mappings
    {
        public AppDbContext()
        {
            this.Session = CreateSession();
            this.Mapper = new Mapper(this.Session);

            this.SetMappings();
        }

        public ISession Session { get; init; }

        public IMapper Mapper { get; init; }

        public static AppDbContext CreateInstance()
        {
            return new AppDbContext();
        }

        public void SetMappings()
        {
            this.For<Item>()
                .TableName("items")
                .PartitionKey(x => x.Id)
                .Column(x => x.Name)
                .Column(x => x.Description);

            this.For<Item>()
                .TableName("items")
                .PartitionKey(x => x.Id)
                .Column(x => x.Name)
                .Column(x => x.Description);
        }

        private static ISession CreateSession()
        {
            var confg = ConfigurationBuilderProvider.Get();

            var cluster = CreateCluster(confg);

            return cluster.Connect(confg.GetDbKeyspace());
        }

        private static Cluster CreateCluster(IConfigurationRoot confg)
            => Cluster
                .Builder()
                .AddContactPoint(confg.GetDbContactPoint())
                .WithPort(confg.GetDbPort())
                .WithCredentials(confg.GetDbUsername(), confg.GetDbPassword())
                .Build();
    }
}
