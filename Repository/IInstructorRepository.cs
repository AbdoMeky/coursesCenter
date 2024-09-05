using coursesCenter.Models.entities;
using coursesCenter.ViewModels;

namespace coursesCenter.Repository
{
    public interface IInstructorRepository
    {
        List<Instructor> GetAll();
        List<Instructor> GetGroupByCourseId(int CourseId);
        Instructor GetById(int id);
        void Save(Instructor instructor);
        void Delete(int id);
        void Edit(Instructor instructor);
        Instructor Details(int id);
    }
}
