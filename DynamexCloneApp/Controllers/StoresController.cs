using System.Collections.Generic;
using System.Linq;
using DynamexCloneApp.DAL;
using DynamexCloneApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DynamexCloneApp.Controllers
{
    public class StoresController : Controller
    {
        private AppDbContext _context;

        public StoresController(AppDbContext context)
        {
            _context = context;
        }
        // GET
        public IActionResult Index()
        {
            List<Store> stores = _context.Stores.ToList();
            return View(stores);
        }
    }
}