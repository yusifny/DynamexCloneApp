using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class NewsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}