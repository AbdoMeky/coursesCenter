using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using Microsoft.EntityFrameworkCore;

namespace coursesCenter.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        AppDbContext Context=new AppDbContext();

        public void Delete(int id)
        {
            var instructor=Context.instructors.Include(x=>x.ApplicationUser).FirstOrDefault(x=>x.Id==id);
            var user=Context.Users.FirstOrDefault(u => u.Id==instructor.ApplicationUser.Id);
            Context.Users.Remove(user);
            Context.instructors.Remove(instructor);
            Context.SaveChanges();
            return;
        }

        public Instructor Details(int id)
        {
            return Context.instructors.Include(x=>x.Course).Include(x=>x.Departrment).SingleOrDefault(x => x.Id == id);
        }

        public void Edit(Instructor instructor)
        {
            var instrctorDB = Context.instructors.FirstOrDefault(x=>x.Id==instructor.Id);
            if (instrctorDB != null)
            {
                instrctorDB.Address=instructor.Address;
                instrctorDB.CourseId=instructor.CourseId;
                instrctorDB.Name=instructor.Name;
                instrctorDB.Salary=instructor.Salary;
                instrctorDB.DepartmentId=instructor.DepartmentId;
                Context.SaveChanges();
            }
            return;
        }

        public List<Instructor> GetAll()
        {
            return Context.instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return Context.instructors.FirstOrDefault(x => x.Id == id);
        }

        public List<Instructor> GetGroupByCourseId(int CourseId)
        {
            return Context.instructors.Where(x=>x.CourseId==CourseId).ToList();
        }

        public void Save(Instructor instructor)
        {
            Context.instructors.Add(instructor);
            Context.SaveChanges();
            return;
        }
    }
}
