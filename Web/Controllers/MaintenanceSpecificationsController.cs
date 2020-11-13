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

namespace Web.Controllers
{
    public class MaintenanceSpecificationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaintenanceSpecificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: MaintenanceSpecifications
        public async Task<IActionResult> Index(DateTime? dateFilter, StatusEnum? statusFilter, string order, string search)
        {
            ViewData["IdSortParm"] = String.IsNullOrEmpty(order) ? "Id_desc" : "";
            ViewData["DateSortParm"] = order == "Date" ? "Date_desc" : "Date";
            ViewData["LicenseNumberSortParm"] = order == "License" ? "License_desc" : "License";
            ViewData["StatusSortParm"] = order == "Status" ? "Status_desc" : "Status";

            ViewData["DateFilter"] = dateFilter;
            ViewData["StatusFilter"] = statusFilter;
            ViewData["SearchFilter"] = search;
            ViewData["CurrenstOrder"] = order;

            var maintenanceSpecifications = statusFilter == null ? await _unitOfWork.MaintenanceSpecifications.GetAllAsync() 
                                                           : await _unitOfWork.MaintenanceSpecifications.WhereAsync(ms => ms.Car.Status == statusFilter);

            if (dateFilter != null)
            {
                maintenanceSpecifications = maintenanceSpecifications.Where(ms => ms.Date <= dateFilter);
            }

            if (search != null)
            {
                search = search.ToLower();
                maintenanceSpecifications = maintenanceSpecifications.Where(ms => ms.Car.LicenseNumber.ToLower().Contains(search));
            }

            maintenanceSpecifications = order switch
            {
                "Id_desc" => maintenanceSpecifications.OrderByDescending(ms => ms.MaintenanceSpecificationId),
                "Date" => maintenanceSpecifications.OrderBy(ms => ms.Date),
                "Date_desc" => maintenanceSpecifications.OrderByDescending(ms => ms.Date),
                "License_desc" => maintenanceSpecifications.OrderByDescending(ms => ms.Car.LicenseNumber),
                "License" => maintenanceSpecifications.OrderBy(ms => ms.Car.LicenseNumber),
                "Status" => maintenanceSpecifications.OrderBy(ms => ms.Car.Status),
                "Status_desc" => maintenanceSpecifications.OrderByDescending(ms => ms.Car.Status),
                _ => maintenanceSpecifications.OrderBy(ms => ms.MaintenanceSpecificationId),
            };

            maintenanceSpecifications = maintenanceSpecifications.Where(ms => ms.Car.Status != null
                                                                        && ms.Car.Status != StatusEnum.SIGNED_OFF);

            return View(maintenanceSpecifications);
        }

        // GET: MaintenanceSpecifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceSpecification = await _unitOfWork.MaintenanceSpecifications
                .FindAsync((int)id);

            if (maintenanceSpecification == null)
            {
                return NotFound();
            }

            return View(maintenanceSpecification);
        }

        // GET: MaintenanceSpecifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceSpecifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("maintenanceSpecificationId,Name")] MaintenanceSpecification maintenanceSpecification)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MaintenanceSpecifications.Add(maintenanceSpecification);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maintenanceSpecification);
        }

        // GET: MaintenanceSpecifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceSpecification = await _unitOfWork.MaintenanceSpecifications.FindAsync((int)id);
            if (maintenanceSpecification == null)
            {
                return NotFound();
            }
            return View(maintenanceSpecification);
        }

        // POST: MaintenanceSpecifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int maintenanceSpecificationId, [Bind("maintenanceSpecificationId,Name")] MaintenanceSpecification maintenanceSpecification)
        {
            if (maintenanceSpecificationId != maintenanceSpecification.MaintenanceSpecificationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.MaintenanceSpecifications.Update(maintenanceSpecification);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceSpecificationExists(maintenanceSpecification.MaintenanceSpecificationId))
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
            return View(maintenanceSpecification);
        }

        // GET: MaintenanceSpecifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenanceSpecification = await _unitOfWork.MaintenanceSpecifications
                .FindAsync((int)id);

            if (maintenanceSpecification == null)
            {
                return NotFound();
            }

            return View(maintenanceSpecification);
        }

        // POST: MaintenanceSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int maintenanceSpecificationId)
        {
            var maintenanceSpecification = await _unitOfWork.MaintenanceSpecifications.FindAsync(maintenanceSpecificationId);
            _unitOfWork.MaintenanceSpecifications.Remove(maintenanceSpecification);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceSpecificationExists(int id)
        {
            return _unitOfWork.MaintenanceSpecifications.Find(id) != null;
        }
    }
}
