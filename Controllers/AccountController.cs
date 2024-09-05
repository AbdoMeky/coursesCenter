using coursesCenter.Models;
using coursesCenter.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace coursesCenter.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View("LogIn");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(logInTraineViewModel logInTraine) 
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByEmailAsync(logInTraine.EmailAddress);
                if (user != null)
                {
                    bool found =await userManager.CheckPasswordAsync(user, logInTraine.Password);
                    if (found)
                    {
                        await signInManager.SignInAsync(user, logInTraine.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "email or password is not valid");
                }
            }
            return View("LogIn", logInTraine);
        }
        [HttpGet]
        public async Task<ActionResult> LogOut() 
        { 
            await signInManager.SignOutAsync();
            return RedirectToAction("LogIn","Account");
        }
    }
}
