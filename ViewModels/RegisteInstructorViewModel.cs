using coursesCenter.Models.entities;
using coursesCenter.Models;
using System.ComponentModel.DataAnnotations;

namespace coursesCenter.ViewModels
{
    public class RegisteInstructorViewModel
    {
        [UniqueMail]
        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        public string Name {  get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        [Range(6000, 25000)]
        public decimal Salary { get; set; }
        [Required]
        //[RegularExpression("[A-Za-z]{3-15}-[A-Za-z]{3-20}-[A-Za-z0-9]{10-30}")]
        public string? Address { get; set; }
        [Display(Name = "Course")]
        [Required]
        public int CourseId { get; set; }
        [Required]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
    }
}
