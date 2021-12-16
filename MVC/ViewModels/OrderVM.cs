using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class OrderVM
    {
        public int Id { get; set; }

        public int BookId { get; set; }
        public virtual BookDTO Book { get; set; }

        public int BuyerId { get; set; }
        public virtual BuyerDTO Buyer { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string DeliveryService { get; set; }


        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Adress { get; set; }

        [Required]
        [Display(Name = "Time of order")]
        [DataType(DataType.Date)]
        public DateTime TimeOfOrder { get; set; }

        public decimal FinalPrice { get; set; }

        public OrderVM() { }

        public OrderVM(OrderDTO orderDTO)
        {
            Id = orderDTO.Id;
            BookId = orderDTO.BookId;
            Book = new BookDTO
            {
                Id = orderDTO.BookId,
                Author = orderDTO.Book.Author,
                Name = orderDTO.Book.Name,
                Pages = orderDTO.Book.Pages,
                Price = orderDTO.Book.Price,
                Publisher = orderDTO.Book.Publisher,
                Year = orderDTO.Book.Year
            };
            BuyerId = orderDTO.BuyerId;
            Buyer = new BuyerDTO
            {
                Id = orderDTO.BuyerId,
                Name = orderDTO.Buyer.Name,
                Age = orderDTO.Buyer.Age,
                Money = orderDTO.Buyer.Money,
                PhoneNumber = orderDTO.Buyer.PhoneNumber,
                Email = orderDTO.Buyer.Email,
                Sex = orderDTO.Buyer.Sex
            };
            Adress = orderDTO.Address;
            DeliveryService = orderDTO.DeliveryService;
            FinalPrice = orderDTO.FinalPrice;
            TimeOfOrder = orderDTO.TimeOfOrder;
        }
    }
}