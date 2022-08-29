using System.Threading.Tasks;
using DynamexCloneApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DynamexCloneApp.Controllers
{
    public class RegisterController : Controller
    {
        private UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(Register register)
        {
            if (!ModelState.IsValid) return View();

            AppUser newUser = new AppUser()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                BirthDate = register.BirthDate,
                IsResident = register.IsResident,
                IdNumber = register.IdNumber,
                IdPin = register.IdPin,
                City = register.City,
                DynamexBranch = register.DynamexBranch,
                HomeAddress = register.HomeAddress,
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, register.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }
            
            return RedirectToAction(nameof(Index), nameof(register));
        }
    }
}