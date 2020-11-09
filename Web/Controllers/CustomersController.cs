using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: CustomersController
        public IActionResult Index(string order, string search)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(order) ? "Name_desc" : "";
            ViewData["CitySortParm"] = order == "City" ? "City_desc" : "City";
            ViewData["ZipcodeSortParm"] = order == "Zipcode" ? "Zipcode_desc" : "Zipcode";

            ViewData["CurrentFilter"] = search;
            ViewData["CurrenstOrder"] = order;


            var customers = from c
                       in _customerRepository.GetAllCustomers()
                       select c;

            if (search != null)
            {
                search = search.ToLower();
                customers = customers.Where(c => c.Name.ToLower().Contains(search)
                                        || c.City.ToLower().Contains(search)
                                        || c.Street.ToLower().Contains(search)
                                        || c.Zipcode.ToLower().Contains(search)
                                        || c.PhoneNumber.ToLower().Contains(search)
                                        || c.Email.ToLower().Contains(search));
            }

            customers = order switch
            {
                "Name_desc" => customers.OrderByDescending(c => c.Name),
                "City" => customers.OrderBy(c => c.City).ThenBy(c => c.Street).ThenBy(c => c.HouseNumber),
                "City_desc" => customers.OrderByDescending(c => c.City).ThenBy(c => c.Street).ThenBy(c => c.HouseNumber),
                "Zipcode" => customers.OrderBy(c => c.Zipcode),
                "Zipcode_desc" => customers.OrderByDescending(c => c.Zipcode),
                _ => customers.OrderBy(c => c.Name),
            };

            return View(customers);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = _customerRepository.GetCustomer(id);
            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,City,Street,HouseNumber,Zipcode,PhoneNumber,Email")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            try
            {
                _customerRepository.AddCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = _customerRepository.GetCustomer(id);
            return View(customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Name,City,Street,HouseNumber,Zipcode,PhoneNumber,Email")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }

            try
            {
                _customerRepository.EditCustomer(id, customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            return View();
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _customerRepository.DeleteCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
