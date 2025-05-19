using System.ComponentModel.DataAnnotations;
using PROG7311POE2.Models;

namespace PROG7311POE2.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }
    }
}
