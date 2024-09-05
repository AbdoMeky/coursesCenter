using coursesCenter.Models;
using coursesCenter.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace coursesCenter.Controllers
{
    public class TraineAccount : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        public TraineAccount(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<int>> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult RegisterTraine()
        {
            return View("RegisterTraine");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterTraine(RegisterTraineViewModel TraineRegiste)
        {
            ApplicationUser user = new ApplicationUser();
            user.Email = TraineRegiste.EmailAddress;
            user.UserName = TraineRegiste.Name;
            IdentityResult result = await userManager.CreateAsync(user, TraineRegiste.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Traine");
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View("RegisterTraine", TraineRegiste);
        }
    }
}
