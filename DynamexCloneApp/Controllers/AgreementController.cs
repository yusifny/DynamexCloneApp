using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class AgreementController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}