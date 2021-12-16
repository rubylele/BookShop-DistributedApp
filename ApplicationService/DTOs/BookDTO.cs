using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime Year { get; set; }

        public int Pages { get; set; }

        public decimal Price { get; set; }

        public string Publisher { get; set; }
    }
}
