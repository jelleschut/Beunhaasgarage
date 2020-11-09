using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: CarsController
        public IActionResult Index(string order, string search)
        {
            ViewData["LicenseNumberParm"] = String.IsNullOrEmpty(order) ? "License_desc" : "";
            ViewData["BrandSortParm"] = order == "Brand" ? "Brand_desc" : "Brand";
            ViewData["ModelSortParm"] = order == "Model" ? "Model_desc" : "Model";
            ViewData["OwnerParm"] = order == "Owner" ? "Owner_desc" : "Owner";
            ViewData["DriverParm"] = order == "Driver" ? "Driver_desc" : "Driver";

            ViewData["CurrentFilter"] = search;
            ViewData["CurrenstOrder"] = order;


            var cars = from c
                       in _unitOfWork.Cars.GetAll()
                       select c;

            if (search != null)
            {
                search = search.ToLower();
                cars = cars.Where(c => c.LicenseNumber.ToLower().Contains(search)
                                        || c.Owner.Name.ToLower().Contains(search)
                                        || c.Driver.Name.ToLower().Contains(search)
                                        || c.Brand.Name.ToLower().Contains(search)
                                        || c.Model.Name.ToLower().Contains(search));
            }

            cars = order switch
            {
                "License_desc" => cars.OrderByDescending(c => c.LicenseNumber),
                "Brand" => cars.OrderBy(c => c.Brand.Name).ThenBy(c => c.Model.Name),
                "Brand_desc" => cars.OrderByDescending(c => c.Brand.Name).ThenBy(c => c.Model.Name),
                "Model" => cars.OrderBy(c => c.Model.Name),
                "Model_desc" => cars.OrderByDescending(c => c.Model.Name),
                "Owner" => cars.OrderBy(c => c.Owner.Name),
                "Owner_desc" => cars.OrderByDescending(c => c.Owner.Name),
                "Driver" => cars.OrderBy(c => c.Driver.Name),
                "Driver_desc" => cars.OrderByDescending(c => c.Driver.Name),
                _ => cars.OrderBy(c => c.LicenseNumber),
            };
            return View(cars);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            Car car = _unitOfWork.Cars.GetById(id);
            return View(car);
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("LicenseNumber,Brand,Model,Owner,Driver")] Car car)
        {

            if (!ModelState.IsValid)
            {
                return View(car);
            }

            try
            {
                _unitOfWork.Cars.Add(car);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            Car car = _unitOfWork.Cars.GetById(id);
            return View(car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("CarId,LicenseNumber,Brand,Model,Owner,Driver")] Car car)
        {

            if (!ModelState.IsValid)
            {
                return View(car);
            }

            try
            {
                _unitOfWork.Cars.Update(car);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            Car car = _unitOfWork.Cars.GetById(id);
            return View(car);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost([Bind("CarId,LicenseNumber,Brand,Model,Owner,Driver")] Car car)
        {
            try
            {
                _unitOfWork.Cars.Remove(car);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
