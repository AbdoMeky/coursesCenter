using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using coursesCenter.Repository;
using coursesCenter.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
namespace coursesCenter.Controllers
{
    public class CourseController : Controller
    {
        IDepartmentRepositorty DepartmentRepo { get; set; }
        ICourseRepository CourseRepo { get; set; }
        public CourseController(ICourseRepository _CourseRepo,IDepartmentRepositorty _DepartmentRepo)
        {
            DepartmentRepo = _DepartmentRepo;
            CourseRepo = _CourseRepo;
        }
        public IActionResult IsValidDegree(decimal Degree, decimal MinDegree)
        {
            if (Degree > MinDegree)
            {
                return Json(true);
            }
            return Json(false);
        }
        [Authorize(Roles = "Manager")]
        public IActionResult Index()
        {
            List<DepartmentsWithCourses> deptWithCourse = DepartmentRepo.GetAllIncludeCoursesInDepartmentWithCoursesVM();
            return View("allCourses", deptWithCourse);
        }
        public IActionResult IndexBeta()
        {
            List<DepartmentsWithCourses> deptWithCourse = DepartmentRepo.GetAllIncludeCoursesInDepartmentWithCoursesVM();
            return View("IndexBeta", deptWithCourse);
        }
        public ActionResult CoursesWithDeletedDepartment()
        {
            return View("CoursesWithDeletedDepartment", CourseRepo.WithDeletedDepartment());
        }
        public IActionResult GetOneCourseById(int Id)
        {
            var course=CourseRepo.GetById(Id);
            if (course == null)
            {
                return Content("Not Found");
            }
            return View("GetOneCourse", course);
        }

        public IActionResult GetOneCourseByName(string Name)
        {
            var course =CourseRepo.GetByName(Name);
            if (course == null)
            {
                return Content("Not Found");
            }
            return View("GetOneCourse", course);
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Add()
        {
            ViewBag.Departments = DepartmentRepo.GetAll();
            return View("Add");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.DepartmentId != 0)
                {
                    CourseRepo.Add(course);
                    return RedirectToAction("Index");
                }
            }
            if (course.DepartmentId == 0)
            {
                ModelState.AddModelError("DepartmentId", "You should select Department");
            }
            ViewBag.Departments = DepartmentRepo.GetAll();
            return View("Add", course);
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Edit(string Name)
        {
            var course = CourseRepo.GetByName(Name);
            ViewBag.Departments = DepartmentRepo.GetAll();
            return View("Edit", course);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.DepartmentId != 0)
                {
                    CourseRepo.Edit(course);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("DepartmentId", "You must select Department");
            }
            ViewBag.Departments = DepartmentRepo.GetAll();
            return View("Edit", course);
        }
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Delete(string Name)
        {
            return View("Delete", Name);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult DeleteCourse(string Name)
        {
            CourseRepo.Delete(Name);
            return RedirectToAction("Index");
        }
        public IActionResult ShowInstructorInCourse()
        {
                return View("ShowInstructorInCourse", CourseRepo.GetAll());
        }
        public ActionResult GetCoursesInDepartment(int deptId)
        {
            return Json(CourseRepo.GetGroupInDepartment(deptId));
        }
    }
}
