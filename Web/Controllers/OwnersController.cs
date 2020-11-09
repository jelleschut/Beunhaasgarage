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
    public class OwnersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OwnersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CustomersController
        public IActionResult Index(string order, string search)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(order) ? "Name_desc" : "";
            ViewData["CitySortParm"] = order == "City" ? "City_desc" : "City";
            ViewData["ZipcodeSortParm"] = order == "Zipcode" ? "Zipcode_desc" : "Zipcode";

            ViewData["CurrentFilter"] = search;
            ViewData["CurrenstOrder"] = order;


            var owners = from c
                       in _unitOfWork.Owners.GetAll()
                       select c;

            if (search != null)
            {
                search = search.ToLower();
                owners = owners.Where(c => c.Name.ToLower().Contains(search)
                                        || c.City.ToLower().Contains(search)
                                        || c.Street.ToLower().Contains(search)
                                        || c.Zipcode.ToLower().Contains(search)
                                        || c.PhoneNumber.ToLower().Contains(search)
                                        || c.Email.ToLower().Contains(search));
            }

            owners = order switch
            {
                "Name_desc" => owners.OrderByDescending(c => c.Name),
                "City" => owners.OrderBy(c => c.City).ThenBy(c => c.Street).ThenBy(c => c.HouseNumber),
                "City_desc" => owners.OrderByDescending(c => c.City).ThenBy(c => c.Street).ThenBy(c => c.HouseNumber),
                "Zipcode" => owners.OrderBy(c => c.Zipcode),
                "Zipcode_desc" => owners.OrderByDescending(c => c.Zipcode),
                _ => owners.OrderBy(c => c.Name),
            };

            return View(owners);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            Owner owner = _unitOfWork.Owners.GetById(id);
            return View(owner);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,City,Street,HouseNumber,Zipcode,PhoneNumber,Email")] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return View(owner);
            }

            try
            {
                _unitOfWork.Owners.Add(owner);
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
            Owner owner = _unitOfWork.Owners.GetById(id);
            return View(owner);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("OwnerId,Name,City,Street,HouseNumber,Zipcode,PhoneNumber,Email")] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return View(owner);
            }

            try
            {
                _unitOfWork.Owners.Update(owner);
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
        public ActionResult DeletePost([Bind("OwnerId,Name,City,Street,HouseNumber,Zipcode,PhoneNumber,Email")] Owner owner)
        {
            try
            {
                _unitOfWork.Owners.Remove(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
