using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PROG7311POE2.Models
{
    public class Farmer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ContactInformation { get; set; }
        public string Location { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
