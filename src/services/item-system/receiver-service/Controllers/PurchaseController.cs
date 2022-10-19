namespace ReceiverService.Controllers
{
    using System.Text.Json;

    using Microsoft.AspNetCore.Mvc;

    using ReceiverService.DTOs;
    using ReceiverService.Services.MessageBus;

    public class PurchaseController : BaseController
    {
        private readonly IMessageBusService messageBusService;

        public PurchaseController(IMessageBusService messageBusService)
        {
            this.messageBusService = messageBusService;
        }

        [HttpPost]
        public IActionResult ForwardRequest(ForwardedRequestData requestData)
        {
            var requestDataAsText = JsonSerializer.Serialize(requestData);

            this.messageBusService.SendMessage(requestDataAsText, "/purchase");

            return this.Ok();
        }
    }
}
