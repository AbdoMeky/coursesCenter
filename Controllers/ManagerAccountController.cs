using coursesCenter.Models.entities;
using coursesCenter.Models;
using coursesCenter.Repository;
using coursesCenter.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace coursesCenter.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerAccountController : Controller
    {
        private readonly IDepartmentRepositorty DepartmentRepo;
        private readonly IManagerRepository ManagerRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        public ManagerAccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<int>> roleManager, IDepartmentRepositorty DepartmentRepo, IManagerRepository ManagerRepo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.DepartmentRepo = DepartmentRepo;
            this.ManagerRepo = ManagerRepo;
        }
        [HttpGet]
        public IActionResult RegisterManager()
        {
            ViewBag.department = DepartmentRepo.GetAll();
            return View("RegisterManager");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterManager(RegisterManagerViewModel ManagerRegiste)
        {
            if (ModelState.IsValid)
            {
                if (ManagerRegiste.DepartmentId == 0)
                {
                    ModelState.AddModelError("", "you should choose department");
                }
                else
                {
                    ApplicationUser user = new ApplicationUser();
                    user.Email = ManagerRegiste.EmailAddress;
                    user.UserName = ManagerRegiste.Name;
                    IdentityResult result = await userManager.CreateAsync(user, ManagerRegiste.Password);
                    if (result.Succeeded)
                    {
                        Manager manager = new Manager();
                        manager.Name = ManagerRegiste.Name;
                        manager.Address = ManagerRegiste.Address;
                        manager.DepartmentId = ManagerRegiste.DepartmentId;
                        manager.ApplicationUserId = user.Id;
                        ManagerRepo.Add(manager);
                        await userManager.AddToRoleAsync(user, "Manager");
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
            return View("RegisterManager", ManagerRegiste);
        }
    }
}
