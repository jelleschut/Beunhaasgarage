using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using DataAccessLayer;
using Core.Interfaces;
using Core.Enums;
using Web.ViewModels;

namespace Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Cars
        public async Task<IActionResult> Index(int? brandFilter, int? modelFilter, int? companyFilter, StatusEnum? statusFilter, string order, string search)
        {


            ViewData["LicenseNumberParm"] = String.IsNullOrEmpty(order) ? "License_desc" : "";
            ViewData["BrandSortParm"] = order == "Brand" ? "Brand_desc" : "Brand";
            ViewData["ModelSortParm"] = order == "Model" ? "Model_desc" : "Model";
            ViewData["StatusSortParm"] = order == "Status" ? "Status_desc" : "Status";



            ViewData["BrandId"] = new SelectList(await _unitOfWork.Brands.GetAllAsync(), "BrandId", "Name");
            ViewData["CompanyId"] = new SelectList(await _unitOfWork.Owners.WhereAsync(o => o.OwnerType == OwnerEnum.LEASECOMPANY), "OwnerId", "Name");

            ViewData["BrandFilter"] = brandFilter;
            ViewData["ModelFilter"] = modelFilter;
            ViewData["CompanyFilter"] = companyFilter;
            ViewData["StatusFilter"] = statusFilter;
            ViewData["SearchFilter"] = search;
            ViewData["CurrenstOrder"] = order;

            var cars = await _unitOfWork.Cars.WhereAsync(c => (brandFilter == null || c.Model.Brand.BrandId == brandFilter)
                                                             && (modelFilter == null || c.Model.ModelId == modelFilter)
                                                             && (companyFilter == null || c.Owner.OwnerId == companyFilter)
                                                             && (statusFilter == null || c.Status == statusFilter));

            if (search != null)
            {
                search = search.ToLower();
                cars = cars.Where(c => c.LicenseNumber.ToLower().Contains(search)
                                            || c.Model.Brand.Name.ToLower().Contains(search)
                                            || c.Model.Name.ToLower().Contains(search)
                                            || c.Status.ToString().ToLower().Contains(search));
            }

            cars = order switch
            {
                "License_desc" => cars.OrderByDescending(c => c.LicenseNumber),
                "Brand" => cars.OrderBy(c => c.Model.Brand.Name).ThenBy(c => c.Model.Name),
                "Brand_desc" => cars.OrderByDescending(c => c.Model.Brand.Name).ThenBy(c => c.Model.Name),
                "Model" => cars.OrderBy(c => c.Model.Name),
                "Model_desc" => cars.OrderByDescending(c => c.Model.Name),
                "Owner" => cars.OrderBy(c => c.Status),
                "Owner_desc" => cars.OrderByDescending(c => c.Status),
                "Status" => cars.OrderBy(c => c.Status),
                "Status_desc" => cars.OrderByDescending(c => c.Status),
                _ => cars.OrderBy(c => c.LicenseNumber),
            };

            return View(cars);
        }

        // GET: Cars
        public async Task<IActionResult> BackLogIndex(string order, string search)
        {
            ViewData["LicenseNumberParm"] = String.IsNullOrEmpty(order) ? "License_desc" : "";
            ViewData["BrandSortParm"] = order == "Brand" ? "Brand_desc" : "Brand";
            ViewData["ModelSortParm"] = order == "Model" ? "Model_desc" : "Model";
            ViewData["StatusSortParm"] = order == "Status" ? "Status_desc" : "Status";

            ViewData["SearchFilter"] = search;
            ViewData["CurrenstOrder"] = order;

            var cars = await _unitOfWork.Cars.GetAllAsync();

            if (search != null)
            {
                search = search.ToLower();
                cars = cars.Where(c => c.LicenseNumber.ToLower().Contains(search)
                                        || c.Model.Brand.Name.ToLower().Contains(search)
                                        || c.Model.Name.ToLower().Contains(search)
                                        || c.Status.ToString().ToLower().Contains(search));
            }

            cars = order switch
            {
                "License_desc" => cars.OrderByDescending(c => c.LicenseNumber),
                "Brand" => cars.OrderBy(c => c.Model.Brand.Name).ThenBy(c => c.Model.Name),
                "Brand_desc" => cars.OrderByDescending(c => c.Model.Brand.Name).ThenBy(c => c.Model.Name),
                "Model" => cars.OrderBy(c => c.Model.Name),
                "Model_desc" => cars.OrderByDescending(c => c.Model.Name),
                "Status" => cars.OrderBy(c => c.Status),
                "Status_desc" => cars.OrderByDescending(c => c.Status),
                _ => cars.OrderBy(c => c.LicenseNumber),
            };

            return View(cars);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["BrandId"] = new SelectList(await _unitOfWork.Brands.GetAllAsync(), "BrandId", "Name");
            ViewData["OwnerId"] = new SelectList(await _unitOfWork.Owners.GetAllAsync(), "OwnerId", "Name");
            ViewData["DriverId"] = new SelectList(await _unitOfWork.Owners.WhereAsync(o => o.OwnerType == OwnerEnum.CUSTOMER), "OwnerId", "Name");

            if (id == null)
            {
                return NotFound();
            }

            var car = await _unitOfWork.Cars
                .FindAsync((int)id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public async Task<IActionResult> Create()
        {
            ViewData["BrandId"] = new SelectList(await _unitOfWork.Brands.GetAllAsync(), "BrandId", "Name");
            ViewData["ModelId"] = new SelectList(await _unitOfWork.Models.GetAllAsync(), "ModelId", "Name");
            ViewData["OwnerId"] = new SelectList(await _unitOfWork.Owners.GetAllAsync(), "OwnerId", "Name");
            ViewData["DriverId"] = new SelectList(await _unitOfWork.Owners.WhereAsync(o => o.OwnerType == OwnerEnum.CUSTOMER), "OwnerId", "Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,LicenseNumber,Status,Model,Owner,Driver")] Car car)
        {
            var owner = _unitOfWork.Owners.Find(car.Owner.OwnerId);
            var driver = _unitOfWork.Owners.Find(car.Driver.OwnerId);
            var model = _unitOfWork.Models.Find(car.Model.ModelId);

            if (ModelState.IsValid)
            {
                _unitOfWork.Cars.Add(car);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["BrandId"] = new SelectList(await _unitOfWork.Brands.GetAllAsync(), "BrandId", "Name");
            ViewData["ModelId"] = new SelectList(await _unitOfWork.Models.GetAllAsync(), "ModelId", "Name");
            ViewData["OwnerId"] = new SelectList(await _unitOfWork.Owners.GetAllAsync(), "OwnerId", "Name");
            ViewData["DriverId"] = new SelectList(await _unitOfWork.Owners.WhereAsync(o => o.OwnerType == OwnerEnum.CUSTOMER), "OwnerId", "Name");

            if (id == null)
            {
                return NotFound();
            }

            var car = await _unitOfWork.Cars.FindAsync((int)id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int carId, [Bind("CarId,LicenseNumber,Status,Model,Owner,Driver")] Car car)
        {

            if (carId != car.CarId)
            {
                return NotFound();
            }

            var owner = _unitOfWork.Owners.Find(car.Owner.OwnerId);
            var driver = _unitOfWork.Owners.Find(car.Driver.OwnerId);
            var model = _unitOfWork.Models.Find(car.Model.ModelId);

            car.Owner = owner;
            car.Driver = driver;
            car.Model = model;

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Cars.Update(car);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _unitOfWork.Cars
                .FindAsync((int)id);

            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int carId)
        {
            var car = await _unitOfWork.Cars.FindAsync(carId);
            _unitOfWork.Cars.Remove(car);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _unitOfWork.Cars.Find(id) != null;
        }
    }
}
