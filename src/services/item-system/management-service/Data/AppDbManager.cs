namespace ManagementService.Data
{
    using Cassandra;
    using Cassandra.Mapping;

    using ManagementService.Data.Models;
    using ManagementService.Infrastructure;

    public class AppDbManager : Mappings
    {
        public AppDbManager()
        {
            this.SetMappings();
        }

        public AppDbContext CreateDbContext()
        {
            var session = CreateSession();
            var mapper = new Mapper(session);

            return new AppDbContext
            {
                Session = session,
                Mapper = mapper,
            };
        }

        public void SetMappings()
        {
            this.For<Category>()
                .TableName("categories")
                .PartitionKey(x => x.Id)
                .Column(x => x.Name);

            this.For<Item>()
                .TableName("items")
                .PartitionKey(x => x.Id)
                .Column(x => x.Name)
                .Column(x => x.Description)
                .Column(x => x.CategoryId);
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
