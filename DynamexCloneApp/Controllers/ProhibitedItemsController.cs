using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class ProhibitedItemsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}