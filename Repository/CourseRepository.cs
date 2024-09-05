using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace coursesCenter.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public AppDbContext Context =new AppDbContext();
        /*public CourseRepository(DbContext _context)
        {
            DbContext Context = _context;
        }*/
        public void Add(Course course)
        {
            Context.Courses.Add(course);
            Context.SaveChanges();
            return;
        }

        public void Delete(string Name)
        {
            Course course = this.GetByName(Name);
            Context.Courses.Remove(course);
            Context.SaveChanges();
            return;
        }

        public void Edit(Course course)
        {
            Course courseDB = GetById(course.Id);
            courseDB.Name = course.Name;
            courseDB.DepartmentId = course.DepartmentId;
            courseDB.Degree = course.Degree;
            courseDB.MinDegree = course.MinDegree;
            Context.SaveChanges();
            return;
        }
        public List<Course> GetAll()
        {
            List<Course> courses = Context.Courses.ToList();
            return courses;
        }

        public Course GetById(int Id)
        {
            Course course = Context.Courses.Include(x => x.Departrment).SingleOrDefault(c => c.Id == Id);
            return course;
        }

        public Course GetByName(string Name)
        {
            Course course = Context.Courses.Include(x => x.Departrment).SingleOrDefault(c => c.Name == Name);
            return course;
        }

        public List<Course> GetGroupInDepartment(int DepartmentId)
        {
            return Context.Courses.Where(x=>x.DepartmentId == DepartmentId).ToList();
        }
        public decimal GitDegree(int id)
        {
            var cours = GetById(id);
            if (cours == null)
            {
                return 0;
            }
            else
            {
                return cours.Degree;
            }
        }
        public List<Course> WithDeletedDepartment()
        {
            List<Course> courseWithNullDept=Context.Courses.Where(x => x.DepartmentId == null).ToList();
            return courseWithNullDept;
        }
    }
}
