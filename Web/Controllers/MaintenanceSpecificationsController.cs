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
    public class MaintenanceSpecificationsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaintenanceSpecificationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: MaintenanceSpecificationsController
        public ActionResult  Index()
        {
            IEnumerable<MaintenanceSpecification> msList =_unitOfWork.MaintenanceSpecifications.GetAll();
            return View(msList);
        }

        // GET: MaintenanceSpecificationsController/Details/5
        public ActionResult Details(int id)
        {
            MaintenanceSpecification ms =_unitOfWork.MaintenanceSpecifications.GetById(id);
            return View(ms);
        }

        // GET: MaintenanceSpecificationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaintenanceSpecificationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Milage,Description,MaintenanceType,Car,Driver,Status")] MaintenanceSpecification ms)
        {
            if (!ModelState.IsValid)
            {
                return View(ms);
            }

            try
            {
               _unitOfWork.MaintenanceSpecifications.Add(ms);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaintenanceSpecificationsController/Edit/5
        public ActionResult Edit(int id)
        {
            MaintenanceSpecification ms =_unitOfWork.MaintenanceSpecifications.GetById(id);
            return View(ms);
        }

        // POST: MaintenanceSpecificationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("MaintenanceSpecificationId,Milage,Description,Type,Car,Driver,Status")] MaintenanceSpecification ms)
        {
            if (!ModelState.IsValid)
            {
                return View(ms);
            }

            try
            {
               _unitOfWork.MaintenanceSpecifications.Update(ms);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MaintenanceSpecificationsController/Delete/5
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            return View();
        }

        // POST: MaintenanceSpecificationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost([Bind("MaintenanceSpecificationId,Milage,Description,Type,Car,Driver,Status")] MaintenanceSpecification ms)
        {

            try
            {
               _unitOfWork.MaintenanceSpecifications.Remove(ms);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
