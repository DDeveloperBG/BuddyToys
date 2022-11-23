namespace ManagementService.Services.Item
{
    using AutoMapper;

    using ManagementService.Data.Models;
    using ManagementService.DTOs.BaseController;
    using ManagementService.DTOs.Item;
    using ManagementService.Services.Data.RequestManager;

    public class ItemService : IItemService
    {
        private readonly IRequestManager requestManager;
        private readonly IMapper mapper;

        public ItemService(IRequestManager requestManager, IMapper mapper)
        {
            this.requestManager = requestManager;
            this.mapper = mapper;
        }

        public async Task<MethodResult> AddItemAsync(AddItemInputModel input)
        {
            try
            {
                var item = this.mapper.Map<Item>(input);

                await this.requestManager.MakeInsertRequestAsync(item);

                return new MethodResult(true, "You successfully added new item.");
            }
            catch (Exception ex)
            {
                return new MethodResult(false, error: ex.Message);
            }
        }
    }
}