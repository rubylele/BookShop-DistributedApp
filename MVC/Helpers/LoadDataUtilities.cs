using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public class LoadDataUtilities
    {
        public static SelectList LoadBookData(string query)
        {
            using (SOAPService.Service1Client service = new MVC.SOAPService.Service1Client())
            {
                return new SelectList(service.GetBooks(query), "Id", "Name");
            }
        }

        public static SelectList LoadBuyerData(string query)
        {
            using (SOAPService.Service1Client service = new MVC.SOAPService.Service1Client())
            {
                return new SelectList(service.GetBuyers(query), "Id", "Name");
            }
        }
    }
}