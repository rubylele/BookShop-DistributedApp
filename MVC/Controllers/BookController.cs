using ApplicationService.DTOs;
using Microsoft.Ajax.Utilities;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index(string query)
        {
            List<BookVM> booksVM = new List<BookVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetBooks(query))
                {
                    booksVM.Add(new BookVM(item));
                }

            }

            return View(booksVM);
        }

        public ActionResult Create(BookVM bookVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        BookDTO bookDTO = new BookDTO
                        {
                            Author = bookVM.Author,
                            Name = bookVM.Name,
                            Pages = bookVM.Pages,
                            Price = bookVM.Price,
                            Publisher = bookVM.Publisher,
                            Year = bookVM.Year

                        };
                        service.PostBook(bookDTO);

                        return RedirectToAction("Index");
                    }

                    return View();

                }
            }

            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteBook(id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            BookVM bookVM = new BookVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                bookVM = new BookVM(service.GetBookById(id));
            }
            return View(bookVM);
        }

        public ActionResult Edit(int id, string query)
        {
            BookVM bookVM = new BookVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                bookVM = new BookVM(service.GetBookById(id));
            }
            return View(bookVM);
        }

        [HttpPost]
        public ActionResult Edit(BookVM bookVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        BookDTO bookDTO = new BookDTO
                        {
                            Id = bookVM.Id,
                            Author = bookVM.Author,
                            Name = bookVM.Name,
                            Pages = bookVM.Pages,
                            Price = bookVM.Price,
                            Publisher = bookVM.Publisher,
                            Year = bookVM.Year

                        };
                        service.PostBook(bookDTO);

                        return RedirectToAction("Index");
                    }

                    return View();

                }
            }

            catch
            {
                return View();
            }
        }

    }
}