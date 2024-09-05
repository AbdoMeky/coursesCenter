using coursesCenter.Models.entities;

namespace coursesCenter.Repository
{
    public interface ICourseResultRepository
    {
        CourseResult GetById(int id);
        List<CourseResult> GetByCourseIdAndTraineId(int courseId, int TraineId);
        public void Save(CourseResult courseResult);
        public void Edit(CourseResult courseResult);
        public void Delete(int Id);
        public List<CourseResult>GetForCourse(int courseId);
        public List<CourseResult> GetForTraine(int traineId);
    }
}
