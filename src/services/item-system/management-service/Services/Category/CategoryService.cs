namespace ManagementService.Services.Category
{
    using AutoMapper;

    using ManagementService.Data.Models;
    using ManagementService.DTOs.BaseController;
    using ManagementService.DTOs.Category;
    using ManagementService.Services.Data.RequestManager;

    public class CategoryService : ICategoryService
    {
        private readonly IRequestManager requestManager;
        private readonly IMapper mapper;

        public CategoryService(IRequestManager requestManager, IMapper mapper)
        {
            this.requestManager = requestManager;
            this.mapper = mapper;
        }

        public async Task<MethodResult> AddCategoryAsync(AddCategoryInputModel input)
        {
            try
            {
                var category = this.mapper.Map<Category>(input);

                await this.requestManager.MakeInsertRequestAsync(category);

                return new MethodResult(true, "You successfully added new category.");
            }
            catch (Exception ex)
            {
                return new MethodResult(false, error: ex.Message);
            }
        }
    }
}
