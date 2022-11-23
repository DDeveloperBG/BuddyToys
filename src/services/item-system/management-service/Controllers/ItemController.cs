namespace ManagementService.Controllers
{
    using ManagementService.Common;
    using ManagementService.DTOs.Item;
    using ManagementService.Services.Item;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ItemController : BaseApiController
    {
        private readonly IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [Authorize(Roles = GlobalConstants.AdminRoleName)]
        public async Task<IActionResult> AddItem(AddItemInputModel input)
        {
            var result = await this.itemService.AddItemAsync(input);

            return this.ReturnResponceBasedOnMethodResult(result);
        }
    }
}
