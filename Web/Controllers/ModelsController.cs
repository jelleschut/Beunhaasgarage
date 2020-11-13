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

namespace Web.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Models
        public async Task<IActionResult> Index(string order, string search)
        {
            ViewData["BrandSortParm"] = String.IsNullOrEmpty(order) ? "Brand_desc" : "";
            ViewData["ModelSortParm"] = order == "Model" ? "Model_desc" : "Model";

            ViewData["SearchFilter"] = search;
            ViewData["CurrenstOrder"] = order;

            var models = await _unitOfWork.Models.GetAllAsync();


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

        // GET: Models/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _unitOfWork.Models
                .FindAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Models/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Models/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("modelId,Name")] Model model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Models.Add(model);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Models/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _unitOfWork.Models.FindAsync((int)id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Models/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int modelId, [Bind("modelId,Name")] Model model)
        {
            if (modelId != model.ModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Models.Update(model);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.ModelId))
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
            return View(model);
        }

        // GET: Models/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _unitOfWork.Models
                .FindAsync((int)id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Models/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int modelId)
        {
            var model = await _unitOfWork.Models.FindAsync(modelId);
            _unitOfWork.Models.Remove(model);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(int id)
        {
            return _unitOfWork.Models.Find(id) != null;
        }
    }
}
