using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class LoginController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}