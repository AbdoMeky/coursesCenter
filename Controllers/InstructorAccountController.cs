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
    public class InstructorAccountController : Controller
    {
        private readonly IDepartmentRepositorty DepartmentRepo;
        private readonly IInstructorRepository InstructorRepo;
        private readonly ICourseRepository CourseRepo;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;
        public InstructorAccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole<int>> roleManager,IDepartmentRepositorty DepartmentRepo,IInstructorRepository InstructorRepo,ICourseRepository CourseRepo)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.DepartmentRepo=DepartmentRepo; 
            this.CourseRepo=CourseRepo;
            this.InstructorRepo=InstructorRepo;
        }
        [HttpGet]
        public IActionResult RegisterInstructor()
        {
            ViewBag.courses = CourseRepo.GetGroupInDepartment(0);
            ViewBag.department = DepartmentRepo.GetAll();
            return View("RegisterInstructor");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterInstructor(RegisteInstructorViewModel InstructorRegiste)
        {
            if (ModelState.IsValid)
            {
                if (InstructorRegiste.DepartmentId == 0)
                {
                    ModelState.AddModelError("", "you sholud choose department");
                }
                else
                {
                    if (InstructorRegiste.CourseId == 0)
                    {
                        ModelState.AddModelError("", "you should choose course");
                    }
                    else
                    {
                        ApplicationUser user = new ApplicationUser();
                        user.Email = InstructorRegiste.EmailAddress;
                        user.UserName = InstructorRegiste.Name;
                        IdentityResult result = await userManager.CreateAsync(user, InstructorRegiste.Password);
                        if (result.Succeeded)
                        {
                            Instructor instructor = new Instructor();
                            instructor.Name = InstructorRegiste.Name;
                            instructor.Address = InstructorRegiste.Address;
                            instructor.Salary = InstructorRegiste.Salary;
                            instructor.DepartmentId = InstructorRegiste.DepartmentId;
                            instructor.CourseId = InstructorRegiste.CourseId;
                            instructor.ApplicationUserId = user.Id;
                            InstructorRepo.Save(instructor);
                            await userManager.AddToRoleAsync(user, "Instructor");
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
            }
            ViewBag.department = DepartmentRepo.GetAll();
            ViewBag.courses = CourseRepo.GetGroupInDepartment(InstructorRegiste.DepartmentId);
            return View("RegisterInstructor", InstructorRegiste);
        }
    }
}
