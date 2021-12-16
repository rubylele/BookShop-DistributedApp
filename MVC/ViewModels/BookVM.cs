using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Author { get; set; }

        [Display(Name = "Year of release")]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }

        public int Pages { get; set; }

        public decimal Price { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Publisher { get; set; }

        public BookVM() { }

        public BookVM(BookDTO bookDTO)
        {
            Id = bookDTO.Id;
            Author = bookDTO.Author;
            Name = bookDTO.Name;
            Pages = bookDTO.Pages;
            Price = bookDTO.Price;
            Publisher = bookDTO.Publisher;
            Year = bookDTO.Year;
        }
    }
}