using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using coursesCenter.Repository;
using coursesCenter.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Linq;

namespace coursesCenter.Controllers
{
    [Authorize(Roles = "Manager,Instructor")]
    public class TraineeController : Controller
    {
        ITraineRepository TraineRepo;
        IDepartmentRepositorty DepartmentRepo;
        public TraineeController(ITraineRepository _TraineRepo, IDepartmentRepositorty _DepartmentRepo)
        {
            TraineRepo = _TraineRepo;
            DepartmentRepo = _DepartmentRepo;

        }
        public IActionResult Index()
        {
            var traines=TraineRepo.GetAllInTraineDepartmentViewModel();
            return View("traineAll", traines);
        }

        public IActionResult GetResultOfOne(int Id)
        {
            var traine = TraineRepo.TraineShowStudentResultViewModel(Id);
            if(traine is null)
            {
                return Content("Error Not Found");
            }
            return View("GetResultOfOne",traine);
        }
        public ActionResult GetTraineInSection(int CourseId)
        {
            return Json(TraineRepo.GetTraineInCourseByCourseId(CourseId));
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.departrments = DepartmentRepo.GetAll();
            return View("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveAdd(Traine traine)
        {
            TraineRepo.Save(traine);
            return RedirectToAction("Index");            
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {

            ViewBag.traine =TraineRepo.GetById(Id);
            if(ViewBag.traine == null)
            {
                return Content("not found");
            }
            ViewBag.departments = DepartmentRepo.GetAll();
            return View("Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveEdit(int Id,Traine traine)
        {
            TraineRepo.Edit(traine);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var traine=TraineRepo.GetById(Id);
            if(traine == null)
            {
                return Content("Not found");
            }
            return View("Delete",traine);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveDelete(int id)
        {
            TraineRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}