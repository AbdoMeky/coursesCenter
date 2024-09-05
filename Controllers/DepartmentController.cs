using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using coursesCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace coursesCenter.Controllers
{
    public class DepartmentController : Controller
    {
        public IDepartmentRepositorty DepartmentRepo;
        public DepartmentController(IDepartmentRepositorty _DepartmentRepo)
        {
            DepartmentRepo=_DepartmentRepo;
        }
        public IActionResult Index()
        {
            var dapartments = DepartmentRepo.GetAll();
            if(dapartments.Count > 0)
            {
                return View("AllDepartments", dapartments);
            }
            return Content("empty");
        }
        public IActionResult Details(int Id)
        {
            var department = DepartmentRepo.Detail(Id);
            if(department == null)
            {
                return Content("Not Found");
            }
            return View("Details",department);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Departrment department)
        {
            if(ModelState.IsValid)
            {
                DepartmentRepo.Add(department);
                return View("AllDepartments", DepartmentRepo.GetAll());
            }
            return View("Add", department);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var department = DepartmentRepo.GetById(Id);
            if(department == null)
            {
                return Content("Not Found");
            }
            return View("Edit", department);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Departrment department)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", department);
            }
            DepartmentRepo.Edit(department);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var department=DepartmentRepo.GetById(Id);
            if (department == null)
            {
                return Content("Not Found");
            }
            return View("Delete",department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Departrment departrment)
        {
            DepartmentRepo.Delete(departrment);
            return RedirectToAction("Index");
        }
    }
}