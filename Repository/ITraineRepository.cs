using coursesCenter.Models.entities;
using coursesCenter.ViewModels;

namespace coursesCenter.Repository
{
    public interface ITraineRepository
    {
        List<TraineDepartmentViewModel> GetAllInTraineDepartmentViewModel();
        Traine GetById(int id);
        Traine GetByIdIncludeCouseResultIncludeCourse(int id);
        ShowStudentResultViewModel TraineShowStudentResultViewModel(int id);
        List<Traine> GetTraineInCourseByCourseId(int courseId);
        OneTraineResultViewModel AllResultOfOne(int id);
        void Save(Traine traine);
        void Delete(int id);
        void Edit(Traine traine);
    }
}
