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
    public class OwnersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Owners
        public async Task<IActionResult> Index(OwnerEnum type, string order, string search)
        {
            ViewData["Type"] = type.ToString();
            ViewData["NameSortParm"] = String.IsNullOrEmpty(order) ? "Name_desc" : "";
            ViewData["CitySortParm"] = order == "City" ? "City_desc" : "City";

            ViewData["SearchFilter"] = search;
            ViewData["CurrenstOrder"] = order;

            var owners = await _unitOfWork.Owners.WhereAsync(o => o.OwnerType == type);

            if (search != null)
            {
                search = search.ToLower();
                owners = owners.Where(c => (c.Name.ToLower().Contains(search)
                                        || c.City.ToLower().Contains(search)));
            }

            owners = order switch
            {
                "Name_desc" => owners.OrderByDescending(c => c.Name),
                "City" => owners.OrderBy(c => c.City).ThenBy(c => c.Street).ThenBy(c => c.HouseNumber),
                "City_desc" => owners.OrderByDescending(c => c.City).ThenBy(c => c.Street).ThenBy(c => c.HouseNumber),
                _ => owners.OrderBy(c => c.Name),
            };

            return View(owners);
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _unitOfWork.Owners
                .FindAsync((int)id);

            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OwnerId,Name,City,Street,HouseNumber,Zipcode,PhoneNumber,Email,OwnerType")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Owners.Add(owner);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index), new { type = (int)owner.OwnerType });
            }
            return View(owner);
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _unitOfWork.Owners.FindAsync((int)id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ownerId, [Bind("OwnerId,Name,City,Street,HouseNumber,Zipcode,PhoneNumber,Email,OwnerType")] Owner owner)
        {
            if (ownerId != owner.OwnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Owners.Update(owner);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OwnerExists(owner.OwnerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { type = (int)owner.OwnerType });
            }
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _unitOfWork.Owners
                .FindAsync((int)id);

            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ownerId)
        {
            var owner = await _unitOfWork.Owners.FindAsync(ownerId);
            _unitOfWork.Owners.Remove(owner);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OwnerExists(int id)
        {
            return _unitOfWork.Owners.Find(id) != null;
        }
    }
}
