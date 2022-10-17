using Microsoft.AspNetCore.Mvc;

namespace ForumService.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
