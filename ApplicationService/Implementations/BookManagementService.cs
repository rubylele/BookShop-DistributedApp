using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class BookManagementService
    {
        private BookShop2SystemDBContext ctx = new BookShop2SystemDBContext();

        public List<BookDTO> Get(string query)
        {
            List<BookDTO> bookDTOs = new List<BookDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                if (query == null)
                {
                    foreach (var item in unitOfWork.BookRepository.Get())
                    {
                        bookDTOs.Add(new BookDTO
                        {
                            Id = item.Id,
                            Author = item.Author,
                            Name = item.Name,
                            Pages = item.Pages,
                            Price = item.Price,
                            Publisher = item.Publisher,
                            Year = item.Year
                        });
                    }
                }
                else
                {
                    foreach (var item in unitOfWork.BookRepository.GetByQuery().Where(c => c.Name.Contains(query)).ToList())
                    {
                        bookDTOs.Add(new BookDTO
                        {
                            Id = item.Id,
                            Author = item.Author,
                            Name = item.Name,
                            Pages = item.Pages,
                            Price = item.Price,
                            Publisher = item.Publisher,
                            Year = item.Year
                        });
                    }
                }
            }
            return bookDTOs;
        }

        public BookDTO GetById(int id)
        {

            BookDTO bookDTO = new BookDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Book book = unitOfWork.BookRepository.GetByID(id);

                bookDTO = new BookDTO
                {
                    Id = book.Id,
                    Author = book.Author,
                    Name = book.Name,
                    Pages = book.Pages,
                    Price = book.Price,
                    Publisher = book.Publisher,
                    Year = book.Year
                };

            }

            return bookDTO;
        }

        public bool Save(BookDTO bookDTO)
        {
            Book Book = new Book()
            {
                Id = bookDTO.Id,
                Author = bookDTO.Author,
                Name = bookDTO.Name,
                Pages = bookDTO.Pages,
                Price = bookDTO.Price,
                Publisher = bookDTO.Publisher,
                Year = bookDTO.Year
            };
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (bookDTO.Id == 0)
                    {
                        unitOfWork.BookRepository.Insert(Book);
                    }
                    else
                    {
                        unitOfWork.BookRepository.Update(Book);
                    }

                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Book Book = ctx.Books.Find(id);
                ctx.Books.Remove(Book);
                ctx.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }

    }
}
