using coursesCenter.Models.entities;
using coursesCenter.Repository;
using coursesCenter.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Security.Claims;

namespace coursesCenter.Controllers
{
    public class CourseResultController : Controller
    {
        ICourseRepository CourseRepo;
        IDepartmentRepositorty DepartmentRepo;
        ITraineRepository TraineRepo;
        ICourseResultRepository CourseResultRepo;
        public CourseResultController(ICourseRepository CourseRepo, IDepartmentRepositorty DepartmentRepo,ITraineRepository TraineRepo,ICourseResultRepository CourseResultRepo)
        {
            this.CourseRepo= CourseRepo;
            this.CourseResultRepo= CourseResultRepo;
            this.DepartmentRepo = DepartmentRepo;
            this.TraineRepo=TraineRepo;
        }
        public IActionResult CheckDegree(int Degree,int CourseId)
        {
            if (Degree >= 0 && Degree <= CourseRepo.GitDegree(CourseId))
            {
                return Json(true);
            }
            return Json(false);
        }
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult OptionsPage()
        {
            return View("OptionsPage");
        }
        public ActionResult OptionsPageBeta()
        {
            return View("OptionPageBeta");
        }
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult SearchById()
        {
            return View("SearchById");
        }
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult ShowCourseResultById(int Id)
        {
            CourseResult result = CourseResultRepo.GetById(Id);
            if (result == null)
            {
                return Content("Not Found");
            }
            return View("showCourseResult", result);
        }
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult SearchByCourseIdAndTraine()
        {
            return View("SearchByCourseIdAndTraine");
        }
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult ShowCourseResultByCourseIdAndTraine(int CourseId,int TraineId)
        {
            CourseResultOfTraineInOneCourseViewModels modelResult = new CourseResultOfTraineInOneCourseViewModels();
            var results=CourseResultRepo.GetByCourseIdAndTraineId(CourseId, TraineId);
            if (results.Count == 0)
            {
                return Content("Not Found");
            }
            modelResult.TraineName = TraineRepo.GetById(TraineId).Name;
            modelResult.CourseName = CourseRepo.GetById(CourseId).Name;
            foreach(var result in results)
            {
                modelResult.results.Add(result.Degree);
            }
            return View("ShowCourseResultByCourseIdAndTraine", modelResult);
        }
        public ActionResult AllResultOfOne()
        {
            string val = (User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var results=TraineRepo.AllResultOfOne(int.Parse(val)); 
            return View("AllResultOfOne",results);
        }
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult SearchByCourseId()
        {
            return View("SearchByCourseId");
        }
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult ShowResultForCourse(int CourseId)
        {
            CourseResultForCourseViewModel modelResult = new CourseResultForCourseViewModel();
            var results=CourseResultRepo.GetForCourse(CourseId);
            if(results.Count == 0)
            {
                return Content("Not Found");
            }
            modelResult.CourseName=CourseRepo.GetById(CourseId).Name;
            foreach(var result in results)
            {
                modelResult.results.Add(new TraineDegree(result.Traine.Name,result.Degree));
            }
            return View("ShowResultForCourse",modelResult);
        }
        [HttpGet]
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult Add()
        {
            ViewBag.department=DepartmentRepo.GetAll();
            ViewBag.course = new List<Course>();
            ViewBag.traine = new List<Traine>();
            return View("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult Add(CourseResult result)
        {
            if (ModelState.IsValid)
            {
                if (result.CourseId != 0)
                {
                    if (result.TraineId != 0)
                    {
                        CourseResultRepo.Save(result);
                        return RedirectToAction("ShowCourseResultByCourseIdAndTraine", new {CourseId=result.CourseId,TraineId=result.TraineId});
                    }
                    ModelState.AddModelError("", "you should choose Traine");
                }
                else
                {
                    ModelState.AddModelError("", "you should choose Course");
                }
            }
            ViewBag.department = DepartmentRepo.GetAll();
            ViewBag.course = CourseRepo.GetGroupInDepartment(result.DepartmentId??0);
            ViewBag.traine = TraineRepo.GetTraineInCourseByCourseId(result.CourseId);
            return View("Add", result);
        }
        [HttpGet]
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult Edit(int Id) {
            var result =CourseResultRepo.GetById(Id);
            ViewBag.department = DepartmentRepo.GetAll();
            ViewBag.course = CourseRepo.GetGroupInDepartment(result.DepartmentId ?? 0);
            ViewBag.traine = TraineRepo.GetTraineInCourseByCourseId(result.CourseId);
            return View("Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult Edit(CourseResult result) {
            if (ModelState.IsValid)
            {
                if (result.CourseId != 0)
                {
                    if (result.TraineId != 0)
                    {
                        CourseResultRepo.Edit(result);
                        return RedirectToAction("ShowCourseResultByCourseIdAndTraine", new { CourseId = result.CourseId, TraineId = result.TraineId });
                    }
                    ModelState.AddModelError("", "you should choose Traine");
                }
                else
                {
                    ModelState.AddModelError("", "you should choose Course");
                }
            }
            ViewBag.department = DepartmentRepo.GetAll();
            ViewBag.course = CourseRepo.GetGroupInDepartment(result.DepartmentId ?? 0);
            ViewBag.traine = TraineRepo.GetTraineInCourseByCourseId(result.CourseId);
            return View("Edit", result);
        }
        [HttpGet]
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult Delete(int id) {
            return View("Delete",CourseResultRepo.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager,Instructor")]
        public ActionResult Delete(CourseResult result) {
            var resultDB = CourseResultRepo.GetById(result.Id);
            CourseResultRepo.Delete(result.Id);
            return RedirectToAction("ShowCourseResultByCourseIdAndTraine", new { CourseId = resultDB.CourseId, TraineId = resultDB.TraineId });
        }
    }
}
