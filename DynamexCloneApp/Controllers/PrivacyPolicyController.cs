using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class PrivacyPolicyController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}