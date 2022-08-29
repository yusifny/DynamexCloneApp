using System.Linq;
using DynamexCloneApp.DAL;
using DynamexCloneApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        
        // GET
        public IActionResult Index()
        {
            HomeVm homeVm = new HomeVm();
            homeVm.sliders = _context.HomeSliders.ToList();
            return View(homeVm);
        }
    }
}