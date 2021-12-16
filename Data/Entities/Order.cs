using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order : BaseEntity
    {

        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }

        public string DeliveryService { get; set; }

        public string Address { get; set; }

        [Required]
        public DateTime TimeOfOrder { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
