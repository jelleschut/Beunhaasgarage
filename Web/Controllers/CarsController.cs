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
        private readonly ICarRepository _carRepository;
        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
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
                       in _carRepository.GetAllCars()
                       select c;

            if (search != null)
            {
                search = search.ToLower();
                cars = cars.Where(c => c.LicenseNumber.ToLower().Contains(search)
                                        || c.Owner.Name.ToLower().Contains(search)
                                        || c.Customer.Name.ToLower().Contains(search)
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
                "Driver" => cars.OrderBy(c => c.Customer.Name),
                "Driver_desc" => cars.OrderByDescending(c => c.Customer.Name),
                _ => cars.OrderBy(c => c.LicenseNumber),
            };
            return View(cars);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            Car car = _carRepository.GetCar(id);
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
                _carRepository.AddCar(car);
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
            Car car = _carRepository.GetCar(id);
            return View(car);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("LicenseNumber,Brand,Model,Owner,Driver")] Car car)
        {

            if (!ModelState.IsValid)
            {
                return View(car);
            }

            try
            {
                _carRepository.EditCar(id, car);
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
            Car car = _carRepository.GetCar(id);
            return View(car);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _carRepository.DeleteCar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
