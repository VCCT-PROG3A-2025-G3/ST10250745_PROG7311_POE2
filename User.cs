using System.ComponentModel.DataAnnotations;

namespace PROG7311POE2.Models
{
        public enum UserRole
        {
            Farmer = 0,
            Employee = 1
        }

        public class User
        {
            [Key]
            public int Id { get; set; }

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
