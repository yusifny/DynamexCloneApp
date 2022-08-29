using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class FaqController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}