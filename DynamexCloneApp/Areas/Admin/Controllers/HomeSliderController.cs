using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DynamexCloneApp.DAL;
using DynamexCloneApp.Helpers;
using DynamexCloneApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeSliderController : Controller
    {
        private AppDbContext _context;
        private IWebHostEnvironment _env;
        
        public HomeSliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        // GET
        public IActionResult Index()
        {
            List<HomeSlider> homeSliders = _context.HomeSliders.ToList();
            return View(homeSliders);
        }
        
        
        
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            HomeSlider dbHomeSlider = await _context.HomeSliders.FindAsync(id);
            if (dbHomeSlider == null) return NotFound();
            return View(dbHomeSlider);
        }
        
        
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            HomeSlider dbHomeSlider = await _context.HomeSliders.FindAsync(id);
            if (dbHomeSlider == null) return NotFound();
            Helper.DeleteFile(_env, "imgs", "index", "second-slider", dbHomeSlider.ImageUrl );
            _context.HomeSliders.Remove(dbHomeSlider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(HomeSlider homeSlider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isTitleExist = _context.HomeSliders.Any(hs => hs.Title.ToLower() == homeSlider.Title.ToLower());
            if (isTitleExist)
            {
                ModelState.AddModelError("Title", $"The slide item titled {homeSlider.Title} already exists.");
                return View();
            }

            HomeSlider newHomeSlider = new HomeSlider();
            newHomeSlider.Title = homeSlider.Title;
            newHomeSlider.Subtitle = homeSlider.Subtitle;
            await _context.HomeSliders.AddAsync(newHomeSlider);

            if (ModelState["Image"].ValidationState ==
                Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return View();
            }

            if (!homeSlider.Image.ContentType.Contains("image"))
            {
                ModelState.AddModelError("Image", "Only Image file");
                return View();
            }

            if (homeSlider.Image.Length / 1024 > 10000)
            {
                ModelState.AddModelError("Image", "Image size should not exceed 10MB");
                return View();
            }
            
            // HomeSlider newHomeSlider = new HomeSlider();
            // newHomeSlider.Title = homeSlider.Title;
            // newHomeSlider.Subtitle = homeSlider.Subtitle;
            // await _context.HomeSliders.AddAsync(newHomeSlider);
            // await _context.SaveChangesAsync();

            string path = _env.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + homeSlider.Image.FileName;
            string result = Path.Combine(path, "imgs", "index", "second-slider", fileName);

            await using (FileStream stream = new FileStream(result, FileMode.Create))
            {
               await homeSlider.Image.CopyToAsync(stream);
            }

            newHomeSlider.ImageUrl = fileName;
            await _context.HomeSliders.AddAsync(newHomeSlider);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        
        
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            HomeSlider dbHomeSlider = await _context.HomeSliders.FindAsync(id);
            if (dbHomeSlider == null) return NotFound();
            
            return View(dbHomeSlider);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(int? id, HomeSlider homeSlider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            HomeSlider dbHomeSlider = await _context.HomeSliders.FindAsync(id);
            
            HomeSlider existTitleHomeSlider = _context.HomeSliders.FirstOrDefault(hs => hs.Title.ToLower() == homeSlider.Title.ToLower());

            if (existTitleHomeSlider != null)
            {
                if (dbHomeSlider != existTitleHomeSlider)
                {
                    ModelState.AddModelError("Title", $"The slide item titled {homeSlider.Title} already exists.");
                    return View();
                }
            }
            
            if (dbHomeSlider == null) return NotFound();
            dbHomeSlider.Title = homeSlider.Title;
            dbHomeSlider.Subtitle = homeSlider.Subtitle;
            dbHomeSlider.ImageUrl = homeSlider.ImageUrl;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}