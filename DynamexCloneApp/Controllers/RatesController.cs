using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class RatesController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}