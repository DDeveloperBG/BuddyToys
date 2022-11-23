namespace ManagementService.Services.Item
{
    using ManagementService.DTOs.BaseController;
    using ManagementService.DTOs.Item;

    public interface IItemService
    {
        Task<MethodResult> AddItemAsync(AddItemInputModel input);
    }
}