namespace ManagementService.Data.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; init; }
    }
}
