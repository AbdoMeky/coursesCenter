using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using System.ComponentModel.DataAnnotations;

public class UniqueNameAttribute : ValidationAttribute
{

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return null;
        }
        using(var content=new AppDbContext())
        {
            Course course = (Course)validationContext.ObjectInstance;
            var courseDB = content.Courses.FirstOrDefault(x => x.Name == value.ToString());
            if(courseDB != null && course.Id!=courseDB.Id)
            {
                return new ValidationResult("this name is used");
            }
            return ValidationResult.Success;
        }
    }
}
