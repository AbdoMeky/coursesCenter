using coursesCenter.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace coursesCenter.Controllers
{
    [Authorize(Roles = "Manager")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> roleManager;
        public RoleController(RoleManager<IdentityRole<int>> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(AddRoleViewModel roleModel) { 
            if(ModelState.IsValid)
            {
                IdentityRole<int> role=new IdentityRole<int>();
                role.Name = roleModel.Name;
                IdentityResult result = await roleManager.CreateAsync(role);
                if(result.Succeeded)
                {
                    return Content("role is added");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View("Add",roleModel);
                }
            }
            return View("Add",roleModel);
        }
    }
}
