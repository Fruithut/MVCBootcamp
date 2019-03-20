using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index()
        {
            var customer = GetCustomers();
            return View(customer);
        }

        public ActionResult Details(int id)
        {
            // retrieve customer from list where id matches
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null) return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer { Id = 1, Name = "Will Smith" },
                new Customer { Id = 2, Name = "Bugs Bunny" }
            };
        }
    }
}