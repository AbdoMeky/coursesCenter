using coursesCenter.Models.entities;

namespace coursesCenter.Repository
{
    public interface IManagerRepository
    {
        void Add(Manager manager);
        void Delete(int id);
    }
}
