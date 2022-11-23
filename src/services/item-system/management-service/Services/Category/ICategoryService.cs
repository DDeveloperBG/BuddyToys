namespace ManagementService.Services.Category
{
    using ManagementService.DTOs.BaseController;
    using ManagementService.DTOs.Category;

    public interface ICategoryService
    {
        Task<MethodResult> AddCategoryAsync(AddCategoryInputModel input);
    }
}
