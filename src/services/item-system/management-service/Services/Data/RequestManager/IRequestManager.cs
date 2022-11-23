namespace ManagementService.Services.Data.RequestManager
{
    public interface IRequestManager
    {
        Task MakeInsertRequestAsync(object tableClass);
    }
}
