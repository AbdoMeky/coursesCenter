using System.ComponentModel.DataAnnotations;

namespace coursesCenter.Models.entities
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Range(6000, 25000)]
        public decimal Salary { get; set; }
        [Required]
        //[RegularExpression("[A-Za-z]{3-15}-[A-Za-z]{3-20}-[A-Za-z0-9]{10-30}")]
        public string? Address { get; set; }
        [Display(Name = "Course")]
        public int? CourseId { get; set; }
        public Course?Course { get; set; }
        [Display(Name="Department")]
        public int? DepartmentId { get; set; }
        public Departrment?Departrment { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
