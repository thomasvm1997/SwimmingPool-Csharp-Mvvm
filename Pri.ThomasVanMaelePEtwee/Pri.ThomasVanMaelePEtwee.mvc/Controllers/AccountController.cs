using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pri.Identity.Fabric.Mvc.Models;
using Pri.ThomasVanMaelePEtwee.core.Entities;

namespace Pri.ThomasVanMaelePEtwee.mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            ApplicationUser applicationUser = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.Firstname,
                LastName = model.Lastname,
                
            };

            if (await _userManager.FindByEmailAsync(model.Username) != null)
            {
                ModelState.AddModelError(string.Empty, "Email is already in use.");
                return View();
            }

            var result = await _userManager.CreateAsync(applicationUser, model.Password);

            if (result.Succeeded)
            {
                
                var roleAssignmentResult = await _userManager.AddToRoleAsync(applicationUser, "Customer");

                if (!roleAssignmentResult.Succeeded)
                {
                    
                    ModelState.AddModelError(string.Empty, "Unable to assign role.");
                    return View(model);
                }


                
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Locked out", "Er is iets misgelopen bij het inloggen");
                }

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");

                }
                ModelState.AddModelError("wrong-password", "Er is iets foutgelopen bij het inloggen, probeer opnieuw!");
                return View();

            }
            else
            {
                ModelState.AddModelError("no-user", "Er is iets misgelopen bij het inloggen");
                return View();
                
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

