using coursesCenter.Models;
using coursesCenter.Models.entities;
using coursesCenter.Repository;
using coursesCenter.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace coursesCenter.Controllers
{
    [Authorize(Roles = "Manager")]
    public class TraineAccountController : Controller
    {
        private readonly IDepartmentRepositorty DepartmentRepo;
        private readonly ITraineRepository TraineRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        public TraineAccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<int>> roleManager, IDepartmentRepositorty DepartmentRepo, ITraineRepository TraineRepo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.DepartmentRepo= DepartmentRepo;
            this.TraineRepo= TraineRepo;
        }
        [HttpGet]
        public IActionResult RegisterTraine()
        {
            ViewBag.department = DepartmentRepo.GetAll();
            return View("RegisterTraine");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterTraine(RegisterTraineViewModel TraineRegiste)
        {
            if(ModelState.IsValid)
            {
                if (TraineRegiste.DepartmentId == 0)
                {
                    ModelState.AddModelError("", "you should choose department");
                }
                else
                {
                    ApplicationUser user = new ApplicationUser();
                    user.Email = TraineRegiste.EmailAddress;
                    user.UserName = TraineRegiste.Name;
                    IdentityResult result = await userManager.CreateAsync(user, TraineRegiste.Password);
                    if (result.Succeeded)
                    {
                        Traine traine = new Traine();
                        traine.Name = TraineRegiste.Name;
                        traine.Address = TraineRegiste.Address;
                        traine.Level = TraineRegiste.Level;
                        traine.DepartmentId = TraineRegiste.DepartmentId;
                        traine.ApplicationUserId = user.Id;
                        TraineRepo.Save(traine);
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
                }
            }
            ViewBag.department = DepartmentRepo.GetAll();
            return View("RegisterTraine", TraineRegiste);
        }
    }
}
