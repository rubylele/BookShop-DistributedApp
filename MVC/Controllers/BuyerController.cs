using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BuyerController : Controller
    {
        // GET: Buyer
        public ActionResult Index(string query)
        {
            List<BuyerVM> buyersVM = new List<BuyerVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetBuyers(query))
                {
                    buyersVM.Add(new BuyerVM(item));
                }

            }

            return View(buyersVM);
        }

        public ActionResult Create(BuyerVM buyerVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        BuyerDTO buyerDTO = new BuyerDTO
                        {
                            Name = buyerVM.Name,
                            Age = buyerVM.Age,
                            Money = buyerVM.Money,
                            PhoneNumber = buyerVM.PhoneNumber,
                            Email = buyerVM.Email,
                            Sex = buyerVM.Sex

                        };
                        service.PostBuyer(buyerDTO);

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
                service.DeleteBuyer(id);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            BuyerVM buyerVM = new BuyerVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                buyerVM = new BuyerVM(service.GetBuyerById(id));
            }
            return View(buyerVM);
        }

        public ActionResult Edit(int id, string query)
        {
            BuyerVM buyerVM = new BuyerVM();
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                buyerVM = new BuyerVM(service.GetBuyerById(id));
            }
            return View(buyerVM);
        }

        [HttpPost]
        public ActionResult Edit(BuyerVM buyerVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        BuyerDTO buyerDTO = new BuyerDTO
                        {
                            Id = buyerVM.Id,
                            Name = buyerVM.Name,
                            Age = buyerVM.Age,
                            Money = buyerVM.Money,
                            PhoneNumber = buyerVM.PhoneNumber,
                            Email = buyerVM.Email,
                            Sex = buyerVM.Sex

                        };
                        service.PostBuyer(buyerDTO);

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