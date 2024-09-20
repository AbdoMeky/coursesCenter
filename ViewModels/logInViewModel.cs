using System.ComponentModel.DataAnnotations;

namespace coursesCenter.ViewModels
{
    public class logInViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EmailAddress { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
