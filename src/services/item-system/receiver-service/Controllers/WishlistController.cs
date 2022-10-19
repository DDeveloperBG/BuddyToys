namespace ReceiverService.Controllers
{
    using System.Text.Json;
    using Microsoft.AspNetCore.Mvc;
    using ReceiverService.DTOs;
    using ReceiverService.Services.MessageBus;

    public class WishlistController : BaseController
    {
        private readonly IMessageBusService messageBusService;

        public WishlistController(IMessageBusService messageBusService)
        {
            this.messageBusService = messageBusService;
        }

        [HttpPost]
        public IActionResult ForwardRequest(ForwardedRequestData requestData)
        {
            var requestDataAsText = JsonSerializer.Serialize(requestData);

            this.messageBusService.SendMessage(requestDataAsText, "/wishlist");

            return this.Ok();
        }
    }
}
