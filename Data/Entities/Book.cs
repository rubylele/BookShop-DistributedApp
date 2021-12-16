using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime Year { get; set; }

        public int Pages { get; set; }

        public decimal Price { get; set; }

        public string Publisher { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
