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
    public class BrandsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Brands
        public async Task<IActionResult> Index(string order, string search)
        {
            ViewData["BrandSortParm"] = String.IsNullOrEmpty(order) ? "Brand_desc" : "";
            ViewData["ModelSortParm"] = order == "Model" ? "Model_desc" : "Model";

            ViewData["SearchFilter"] = search;
            ViewData["CurrenstOrder"] = order;

            var brands = await _unitOfWork.Brands.GetAllAsync();
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

            return View(brands);
        }

        // GET: Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _unitOfWork.Brands
                .FindAsync((int)id);

            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // GET: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("brandId,Name")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Brands.Add(brand);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _unitOfWork.Brands.FindAsync((int)id);
            if (brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int brandId, [Bind("brandId,Name")] Brand brand)
        {
            if (brandId != brand.BrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Brands.Update(brand);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandExists(brand.BrandId))
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
            return View(brand);
        }

        // GET: Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brand = await _unitOfWork.Brands
                .FindAsync((int)id);

            if (brand == null)
            {
                return NotFound();
            }

            return View(brand);
        }

        // POST: Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int brandId)
        {
            var brand = await _unitOfWork.Brands.FindAsync(brandId);
            _unitOfWork.Brands.Remove(brand);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandExists(int id)
        {
            return _unitOfWork.Brands.Find(id) != null;
        }
    }
}
