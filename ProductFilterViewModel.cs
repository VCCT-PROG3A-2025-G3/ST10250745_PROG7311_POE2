using System;
using System.Collections.Generic;

namespace PROG7311POE2.Models
{
    public class ProductFilterViewModel
    {
        public string Category { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public List<Product> FilteredProducts { get; set; }
    }
}
