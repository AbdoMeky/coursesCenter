using System.ComponentModel.DataAnnotations;
namespace coursesCenter.Models.entities
{
    public class Departrment
    {
        public int Id { get; set; }
        [Required]
        [UniqueDepartmentName]
        public string Name { get; set; }
        public Manager? Manager { get; set; }
        public ICollection<Course>Courses { get; set; }
        public ICollection<Instructor>Instructors { get; set; }
        public ICollection<Traine>Traines { get; set; }
    }
}
