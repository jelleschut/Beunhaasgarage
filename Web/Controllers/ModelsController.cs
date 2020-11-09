using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ModelsController : Controller
    {
        // GET: ModelsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ModelsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModelsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModelsController/Create
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

        // GET: ModelsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModelsController/Edit/5
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

        // GET: ModelsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModelsController/Delete/5
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
