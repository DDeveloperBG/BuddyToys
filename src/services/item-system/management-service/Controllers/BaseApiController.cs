namespace ManagementService.Controllers
{
    using ManagementService.DTOs.BaseController;

    using Microsoft.AspNetCore.Mvc;

    public abstract class BaseApiController : ControllerBase
    {
        public IActionResult ReturnResponceBasedOnMethodResult(MethodResult methodResult, bool returnMessage = true)
        {
            if (methodResult.IsSuccessful)
            {
                if (returnMessage)
                {
                    return this.Ok(methodResult.SuccessMessage);
                }

                return this.Ok();
            }

            if (returnMessage)
            {
                return this.BadRequest(methodResult.Error);
            }

            return this.BadRequest();
        }
    }
}
