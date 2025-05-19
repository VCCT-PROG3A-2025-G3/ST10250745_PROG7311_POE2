using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROG7311POE2.Models
{
    public class CreateFarmerViewModel
    {
        [Required]
        public int UserId { get; set; }

        public List<SelectListItem> AvailableUsers { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
