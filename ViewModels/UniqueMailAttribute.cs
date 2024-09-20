using coursesCenter.Models;
using coursesCenter.Models.data;
using coursesCenter.Models.entities;
using System.ComponentModel.DataAnnotations;

namespace coursesCenter.ViewModels
{
    public class UniqueMailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            using (var content = new AppDbContext())
            {
                var courseDB = content.Users.FirstOrDefault(x => x.Email == value.ToString());
                if (courseDB != null)
                {
                    return new ValidationResult("this Email is used");
                }
                return ValidationResult.Success;
            }
        }
    }
}
