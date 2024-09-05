using coursesCenter.Models.entities;
using coursesCenter.ViewModels;

namespace coursesCenter.Repository
{
    public interface IDepartmentRepositorty
    {
        List<DepartmentsWithCourses> GetAllIncludeCoursesInDepartmentWithCoursesVM();
        List<Departrment> GetAll();
        Departrment Detail(int id);
        void Add(Departrment departrment);
        void Delete(Departrment departrment);
        void Edit(Departrment departrment);
        Departrment GetById(int id);
    }
}
