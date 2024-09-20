using coursesCenter.Models.entities;
using Microsoft.AspNetCore.Identity;

namespace coursesCenter.Models
{
    public class ApplicationUser :IdentityUser<int>
    {
        public Traine? Traine{ get; set; }
        public Instructor? Instructor { get; set; }
        public Manager? Manager { get; set; }
    }
}
