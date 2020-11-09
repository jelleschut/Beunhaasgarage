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
        private readonly IMaintenanceSpecificationRepository _msRepository;

        public MaintenanceSpecificationsController(IMaintenanceSpecificationRepository msRepository)
        {
            _msRepository = msRepository;
        }
        // GET: MaintenanceSpecificationsController
        public ActionResult  Index()
        {
            List<MaintenanceSpecification> msList = _msRepository.GetAllMaintenanceSpecifications();
            return View(msList);
        }

        // GET: MaintenanceSpecificationsController/Details/5
        public ActionResult Details(int id)
        {
            MaintenanceSpecification ms = _msRepository.GetMaintenanceSpecification(id);
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
        public ActionResult Create([Bind("Milage,Description,Type,Car,Driver,Status")] MaintenanceSpecification ms)
        {
            if (!ModelState.IsValid)
            {
                return View(ms);
            }

            try
            {
                _msRepository.AddMaintenanceSpecification(ms);
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
            MaintenanceSpecification ms = _msRepository.GetMaintenanceSpecification(id);
            return View(ms);
        }

        // POST: MaintenanceSpecificationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Milage,Description,Type,Car,Driver,Status")] MaintenanceSpecification ms)
        {
            if (!ModelState.IsValid)
            {
                return View(ms);
            }

            try
            {
                _msRepository.EditMaintenanceSpecification(id, ms);
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
        public ActionResult DeletePost(int id)
        {

            try
            {
                _msRepository.DeleteMaintenanceSpecification(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
