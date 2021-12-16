using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index(string query)
        {
            List<OrderVM> ordersVM = new List<OrderVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetOrders(query))
                {
                    ordersVM.Add(new OrderVM(item));
                }

            }

            return View(ordersVM);

        }

        public ActionResult Details(int id)
        {
            OrderVM orderVM = new OrderVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var orderDTO = service.GetOrderById(id);
                orderVM = new OrderVM(orderDTO);
            }

            return View(orderVM);
        }

        public ActionResult Create(string query)
        {
            ViewBag.Books = Helpers.LoadDataUtilities.LoadBookData(query);
            ViewBag.Buyers = Helpers.LoadDataUtilities.LoadBuyerData(query);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM orderVM, string query)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    OrderDTO orderDTO = new OrderDTO
                    
                    {
                        BookId = orderVM.BookId,
                        Book = new BookDTO
                        {
                            Id = orderVM.BookId
                        },

                        BuyerId = orderVM.BuyerId,
                        Buyer = new BuyerDTO
                        {
                            Id = orderVM.BuyerId
                        },

                        DeliveryService = orderVM.DeliveryService,
                        Address = orderVM.Adress,
                        TimeOfOrder = orderVM.TimeOfOrder,
                        FinalPrice = orderVM.FinalPrice
                    };

                    service.PostOrder(orderDTO);
                    
                }

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Books = Helpers.LoadDataUtilities.LoadBookData(query);
                ViewBag.Buyers = Helpers.LoadDataUtilities.LoadBuyerData(query);

                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteOrder(id);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id, string query)
        {
            OrderVM orderVM = new OrderVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                orderVM = new OrderVM(service.GetOrderById(id));
                ViewBag.Books = Helpers.LoadDataUtilities.LoadBookData(query);
                ViewBag.Buyers = Helpers.LoadDataUtilities.LoadBuyerData(query);
            }
            return View(orderVM);
        }

        [HttpPost]
        public ActionResult Edit(OrderVM orderVM, string query)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        OrderDTO orderDTO = new OrderDTO
                        {
                            Id = orderVM.Id,
                            BookId = orderVM.BookId,
                            Book = new BookDTO
                            {
                                Id = orderVM.BookId
                            },
                            BuyerId = orderVM.BuyerId,
                            Buyer = new BuyerDTO
                            {
                                Id = orderVM.BuyerId
                            },
                            Address = orderVM.Adress,
                            DeliveryService = orderVM.DeliveryService,
                            FinalPrice = orderVM.FinalPrice,
                            TimeOfOrder = orderVM.TimeOfOrder

                        };
                        service.PostOrder(orderDTO);

                        return RedirectToAction("Index");
                    }

                    return View();

                }
            }

            catch
            {
                ViewBag.Books = Helpers.LoadDataUtilities.LoadBookData(query);
                ViewBag.Buyers = Helpers.LoadDataUtilities.LoadBuyerData(query);

                return View();
            }
        }

    }


}