using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class BuyerDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte Age { get; set; }

        public decimal Money { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Sex { get; set; }
    }
}
