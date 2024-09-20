using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using Microsoft.EntityFrameworkCore;

namespace coursesCenter.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        AppDbContext context=new AppDbContext();
        public void Add(Manager manager)
        {
            context.Managers.Add(manager);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var manager = context.Managers.Include(x=>x.ApplicationUser).FirstOrDefault(x => x.Id == id);
            var user = context.Users.FirstOrDefault(x => x.Id == manager.ApplicationUser.Id);
            context.Managers.Remove(manager);
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}
