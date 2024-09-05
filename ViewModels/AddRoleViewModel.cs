using System.ComponentModel.DataAnnotations;

namespace coursesCenter.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        public string Name {  get; set; }
    }
}
