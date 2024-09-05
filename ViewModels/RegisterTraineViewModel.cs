using System.ComponentModel.DataAnnotations;

namespace coursesCenter.ViewModels
{
    public class RegisterTraineViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Name {  get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
