using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public virtual BookDTO Book { get; set; }
        
        public int BuyerId { get; set; }
        public virtual BuyerDTO Buyer { get; set; }

        public string DeliveryService { get; set; }

        public string Address { get; set; }

        [Required]
        public DateTime TimeOfOrder { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
