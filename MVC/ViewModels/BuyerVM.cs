using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class BuyerVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        public byte Age { get; set; }

        public decimal Money { get; set; }

        public int PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Sex { get; set; }

        public BuyerVM() { }

        public BuyerVM(BuyerDTO buyerDTO)
        {
            Id = buyerDTO.Id;
            Name = buyerDTO.Name;
            Age = buyerDTO.Age;
            Money = buyerDTO.Money;
            PhoneNumber = buyerDTO.PhoneNumber;
            Email = buyerDTO.Email;
            Sex = buyerDTO.Sex;
        }
    }
}