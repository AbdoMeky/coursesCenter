using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace coursesCenter.Models.entities
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [UniqueName]
        public string Name { get; set; }
        [Range(50,100)]
        [Remote(action: "IsValidDegree", controller: "Course", ErrorMessage = "Degree must be bigger than MinDegree", AdditionalFields = "MinDegree")]

        public decimal Degree { get; set; }
        [Range (20,50)]
        public decimal MinDegree { get; set; }
        [Display(Name = "Department Name")]
        
        public int? DepartmentId { get; set; }
        public Departrment Departrment { get; set; }

        public ICollection<Instructor>?Instructors { get; set; }

        //public ICollection<Traine> Traines { get; set; }

        public ICollection<CourseResult>?courseResults { get; set; }
        public List<TraineCourse>?Trainecourses { get; set; }

    }
}
