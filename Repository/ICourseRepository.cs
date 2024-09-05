using coursesCenter.Models.entities;

namespace coursesCenter.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int Id);
        Course GetByName(string Name);
        void Add(Course course);
        void Edit(Course course);
        void Delete(String Name);
        List<Course>GetGroupInDepartment(int DepartmentId);
        List<Course> WithDeletedDepartment();
        decimal GitDegree(int id);
    }
}
