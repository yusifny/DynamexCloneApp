using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class ServicesController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}