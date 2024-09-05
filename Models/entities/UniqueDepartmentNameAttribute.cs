using coursesCenter.Models.data;
using System.ComponentModel.DataAnnotations;

namespace coursesCenter.Models.entities
{
    public class UniqueDepartmentNameAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return null;
            using (var context = new AppDbContext())
            {
                var department = (Departrment)validationContext.ObjectInstance;
                var departmentDB = context.departrments.FirstOrDefault(x => x.Name == value.ToString());
                if (departmentDB == null|| department.Id==departmentDB.Id)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("This name is used");
            }
        }
    }
}
