using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace coursesCenter.Repository
{
    public class CourseResultRepository : ICourseResultRepository
    {
        AppDbContext context = new AppDbContext();
        public void Delete(int Id)
        {
            CourseResult result = GetById(Id);
            context.CourseResults.Remove(result);
            context.SaveChanges();
            return;
        }

        public void Edit(CourseResult courseResult)
        {
            CourseResult result = GetById(courseResult.Id);
            result.Degree = courseResult.Degree;
            context.SaveChanges();
            return;
        }

        public List<CourseResult> GetByCourseIdAndTraineId(int courseId, int traineId)
        {
            return context.CourseResults.Where(x => x.CourseId == courseId && x.TraineId == traineId).ToList();
        }

        public CourseResult GetById(int id)
        {
            return context.CourseResults.Include(x=>x.Course).Include(x=>x.Traine).FirstOrDefault(x => x.Id == id);
        }

        public List<CourseResult> GetForCourse(int courseId)
        {
            return context.CourseResults.Include(x => x.Traine).Where(x=>x.CourseId==courseId).ToList();
        }

        public List<CourseResult> GetForTraine(int traineId)
        {
            return context.CourseResults.Include(x => x.Course).Where(x => x.TraineId == traineId).ToList();
        }

        public void Save(CourseResult courseResult)
        {
            context.CourseResults.Add(courseResult);
            context.SaveChanges();
            return;
        }
    }
}
