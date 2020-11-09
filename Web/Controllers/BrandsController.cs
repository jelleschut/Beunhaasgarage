using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IModelRepository _modelRepository;

        public BrandsController(IBrandRepository brandRepository, IModelRepository modelRepository)
        {
            _brandRepository = brandRepository;
            _modelRepository = modelRepository;
        }

        // GET: BrandsController
        public IActionResult Index(string order, string search)
        {
            ViewData["BrandSortParm"] = String.IsNullOrEmpty(order) ? "Brand_desc" : "";
            ViewData["ModelSortParm"] = order == "Model" ? "Model_desc" : "Model";

            ViewData["CurrentFilter"] = search;
            ViewData["CurrenstOrder"] = order;

            var models = from m
                         in _modelRepository.GetAllModels()
                         select m;

            if (search != null)
            {
                search = search.ToLower();
                models = models.Where(m => m.Brand.Name.ToLower().Contains(search)
                                        || m.Name.ToLower().Contains(search));
            }

            models = order switch
            {
                "Brand_desc" => models.OrderByDescending(m => m.Brand.Name).ThenBy(m => m.Name),
                "Model" => models.OrderBy(m => m.Name),
                "Model_desc" => models.OrderByDescending(m => m.Name),
                _ => models.OrderBy(m => m.Name).ThenBy(m => m.Name).ThenBy(m => m.Name),
            };

            return View(models);
        }

        // GET: BrandsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BrandsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandsController/Create
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

        // GET: BrandsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BrandsController/Edit/5
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

        // GET: BrandsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BrandsController/Delete/5
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
