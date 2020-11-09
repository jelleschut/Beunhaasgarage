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
    public class LeaseCompaniesController : Controller
    {
        private readonly ILeaseCompanyRepository _leaseCompanyRepository;
        public LeaseCompaniesController(ILeaseCompanyRepository leaseCompanyRepository)
        {
            _leaseCompanyRepository = leaseCompanyRepository;
        }

        // GET: LeaseCompaniesController
        public ActionResult Index(string order, string search)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(order) ? "Name_desc" : "";
            ViewData["CitySortParm"] = order == "City" ? "City_desc" : "City";
            ViewData["ZipcodeSortParm"] = order == "Zipcode" ? "Zipcode_desc" : "Zipcode";

            ViewData["CurrentFilter"] = search;
            ViewData["CurrenstOrder"] = order;


            var leaseCompanies = from lc
                            in _leaseCompanyRepository.GetAllLeasecompanies()
                            select lc;

            if (search != null)
            {
                search = search.ToLower();
                leaseCompanies = leaseCompanies.Where(lc => lc.Name.ToLower().Contains(search)
                                                         || lc.City.ToLower().Contains(search)
                                                         || lc.Street.ToLower().Contains(search)
                                                         || lc.Zipcode.ToLower().Contains(search));
            }

            leaseCompanies = order switch
            {
                "Name_desc" => leaseCompanies.OrderByDescending(lc => lc.Name),
                "City" => leaseCompanies.OrderBy(lc => lc.City).ThenBy(lc => lc.Street).ThenBy(lc => lc.HouseNumber),
                "City_desc" => leaseCompanies.OrderByDescending(lc => lc.City).ThenBy(lc => lc.Street).ThenBy(lc => lc.HouseNumber),
                "Zipcode" => leaseCompanies.OrderBy(lc => lc.Zipcode),
                "Zipcode_desc" => leaseCompanies.OrderByDescending(lc => lc.Zipcode),
                _ => leaseCompanies.OrderBy(lc => lc.Name),
            };

            return View(leaseCompanies);
        }

        // GET: LeaseCompaniesController/Details/5
        public ActionResult Details(int id)
        {
            LeaseCompany leaseCompany = _leaseCompanyRepository.GetLeaseCompany(id);
            return View(leaseCompany);
        }

        // GET: LeaseCompaniesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaseCompaniesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaseCompaniesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaseCompaniesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaseCompaniesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaseCompaniesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
