using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using coursesCenter.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace coursesCenter.Repository
{
    public class DepartmentRepository : IDepartmentRepositorty
    {
        public AppDbContext Context=new AppDbContext();
        public List<DepartmentsWithCourses> GetAllIncludeCoursesInDepartmentWithCoursesVM()
        {
            List<Departrment> Departments = Context.departrments.Include(x => x.Courses).ToList();
            List<DepartmentsWithCourses> deptWithCourse = new List<DepartmentsWithCourses>();
            foreach (var department in Departments)
            {
                DepartmentsWithCourses deptWCourse = new DepartmentsWithCourses();
                deptWCourse.Department = department.Name;
                foreach (var curs in department.Courses)
                {
                    deptWCourse.Courses.Add(curs.Name);
                }
                deptWithCourse.Add(deptWCourse);
            }
            return deptWithCourse;
        }
        
        public List<Departrment> GetAll()
        {
            return Context.departrments.ToList();
        }
        public Departrment Detail(int id)
        {
            return Context.departrments.Include(x=>x.Instructors).Include(x=>x.Courses).Include(x=>x.Traines).FirstOrDefault(x => x.Id == id);
        }

        public void Add(Departrment departrment)
        {
            Context.departrments.Add(departrment);
            Context.SaveChanges();
            return;
        }

        public void Delete(Departrment departrment)
        {
            Context.departrments.Remove(departrment);
            Context.SaveChanges();
            return;
        }

        public void Edit(Departrment departrment)
        {
            var departmentDB = Context.departrments.FirstOrDefault(x => x.Id == departrment.Id);
            departmentDB.Name= departrment.Name;
            Context.SaveChanges();
            return;
        }

        public Departrment GetById(int id)
        {
            return Context.departrments.FirstOrDefault(x => x.Id == id);
        }
    }
}
