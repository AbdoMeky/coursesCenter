using System.ComponentModel.DataAnnotations;

namespace coursesCenter.Models.entities
{
    public class Traine
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Address { get; set; }
        public int Level {  get; set; }
        public int?DepartmentId { get; set; }
        public Departrment?Departrment { get; set; }

        public ICollection<CourseResult>?CourseResults { get; set; }
        public List<TraineCourse>? TraineCourses { get; set; }
        public int ApplicationUserId {  get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
