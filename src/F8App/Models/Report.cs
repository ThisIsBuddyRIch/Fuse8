using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F8App.Models
{
    public class Report
    {
        public int OrderId { get; set;}

        public DateTime? OrderDate { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public Int16? Quantity { get; set; }

        public decimal? PriceForUnit { get; set; }
    }
}
