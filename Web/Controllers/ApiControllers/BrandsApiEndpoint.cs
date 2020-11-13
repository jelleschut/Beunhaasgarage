using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using DataAccessLayer;
using Core.Interfaces;

namespace Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsApiEndpoint : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandsApiEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/BrandsApiEndpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            var brands =  await _unitOfWork.Brands.GetAllAsync();
            if(brands == null)
            {
                return NotFound();
            }
            return Ok(brands);
        }

        // GET: api/BrandsApiEndpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            var brand = await _unitOfWork.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        // PUT: api/BrandsApiEndpoint/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrand(int id, Brand brand)
        {
            if (id != brand.BrandId)
            {
                return BadRequest();
            }

            _unitOfWork.Brands.UpdateAsync(brand);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BrandsApiEndpoint
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand([Bind("Name")]Brand brand)
        {
            _unitOfWork.Brands.Add(brand);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetBrand", new { id = brand.BrandId }, brand);
        }

        // DELETE: api/BrandsApiEndpoint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> DeleteBrand(int id)
        {
            var brand = await _unitOfWork.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _unitOfWork.Brands.Remove(brand);
            await _unitOfWork.CompleteAsync();

            return brand;
        }

        private bool BrandExists(int id)
        {
            return _unitOfWork.Brands.Find(id) != null;
        }
    }
}
