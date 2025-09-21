using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using PF_LAB3_BSIT32A3_Xyrylle_Claire_Matiga.Areas.Identity.Data;

namespace PF_LAB3_BSIT32A3_Xyrylle_Claire_Matiga.Controllers
{
    public class HomeController : Controller
    {
        // Change from IdentityUser to ApplicationUser
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        // Update the constructor to use ApplicationUser
        public HomeController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Default home page
        public IActionResult Index()
        {
            return View();
        }

        // ABOUT PAGE
        public IActionResult About()
        {
            ViewData["Message"] = "This is the About page of your Greed Island Project!";
            return View();
        }

        // LOGIN PAGE (GET)
        // Note: It's better to handle Login/Logout in a separate AccountController
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN PAGE (POST)
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        // LOGOUT
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}