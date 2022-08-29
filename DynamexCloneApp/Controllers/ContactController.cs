using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class ContactController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}