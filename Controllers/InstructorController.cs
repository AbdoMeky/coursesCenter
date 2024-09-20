using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using coursesCenter.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace coursesCenter.Controllers
{
    
    
    public class InstructorController : Controller
    {
        IInstructorRepository InstructorRepo;
        IDepartmentRepositorty departmentRepo;
        ICourseRepository courseRepo;
        public InstructorController(IInstructorRepository _InstructorRepo, IDepartmentRepositorty departmentRepo, ICourseRepository courseRepo)
        {
            InstructorRepo = _InstructorRepo;
            this.departmentRepo = departmentRepo;
            this.courseRepo=courseRepo;
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            return View("Index",InstructorRepo.GetAll());
        }
        public IActionResult IndexBeta()
        {
            return View("IndexBeta", InstructorRepo.GetAll());
        }
        public IActionResult Details(int Id)
        {
            var instructor = InstructorRepo.Details(Id);
            if (instructor == null)
            {
                return Content("Not Found");
            }
            return View("Details",instructor);
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Add()
        {
            ViewBag.departments=departmentRepo.GetAll();
            ViewBag.courses=courseRepo.GetGroupInDepartment(0);
            return View("Add");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Add(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                if (instructor.DepartmentId != 0)
                {
                    if (instructor.CourseId != 0)
                    {
                        InstructorRepo.Save(instructor);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("CourseId", "You should choose Course");
                    }
                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "You should choose Department");
                }
            }
            ViewBag.departments = departmentRepo.GetAll();
            int deptId = instructor.DepartmentId??0;
            ViewBag.courses = courseRepo.GetGroupInDepartment(deptId);
            return View("Add", instructor);
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Edit(int Id)
        {
            var instructor=InstructorRepo.GetById(Id);
            if (instructor == null)
            {
                return Content("Not Found");
            }
            ViewBag.departments = departmentRepo.GetAll();
            int deptId = instructor.DepartmentId ?? 0;
            if (deptId != 0)
            {
                ViewBag.courses = courseRepo.GetGroupInDepartment(deptId);
            }
            return View("Edit",instructor);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Edit(Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                if (instructor.DepartmentId != 0)
                {
                    if (instructor.CourseId != 0)
                    {
                        InstructorRepo.Edit(instructor);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("CourseId", "You should choose Course");
                    }
                }
                else
                {
                    ModelState.AddModelError("DepartmentId", "You should choose Department");
                }
            }
            ViewBag.departments = departmentRepo.GetAll();
            int deptId = instructor.DepartmentId ?? 0;
            if (deptId != 0)
            {
                ViewBag.courses = courseRepo.GetGroupInDepartment(deptId);
            }
            return View("Edit", instructor);
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Delete(int Id)
        {
            var instructor = InstructorRepo.GetById(Id);
            if (instructor == null)
            {
                return Content("Not Found");
            }
            return View("Delete",instructor);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult DeleteI(int Id)
        {
            InstructorRepo.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
