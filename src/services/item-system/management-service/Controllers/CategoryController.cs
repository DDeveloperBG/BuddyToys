namespace ManagementService.Controllers
{
    using ManagementService.Common;
    using ManagementService.DTOs.Category;
    using ManagementService.Services.Category;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public async Task<IActionResult> AddCategory(AddCategoryInputModel input)
        {
            var result = await this.categoryService.AddCategoryAsync(input);

            return this.ReturnResponceBasedOnMethodResult(result);
        }
    }
}
