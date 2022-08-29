using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class AboutController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}