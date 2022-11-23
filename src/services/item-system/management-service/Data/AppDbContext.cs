namespace ManagementService.Data
{
    using Cassandra;
    using Cassandra.Mapping;

    public class AppDbContext
    {
        public ISession Session { get; init; }

        public IMapper Mapper { get; init; }
    }
}
