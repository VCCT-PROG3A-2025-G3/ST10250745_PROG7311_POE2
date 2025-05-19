using System;
using System.ComponentModel.DataAnnotations;

namespace PROG7311POE2.Models
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }
    }
}
