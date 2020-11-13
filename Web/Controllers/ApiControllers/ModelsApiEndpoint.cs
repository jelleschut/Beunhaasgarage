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
using Newtonsoft.Json;

namespace Web.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsApiEndpoint : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModelsApiEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ModelsApiEndpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>>> GetModels()
        {
            var models = await _unitOfWork.Models.GetAllAsync();
            if (models == null)
            {
                return NotFound();
            }
            return Ok(models);
        }

        // GET: api/ModelsApiEndpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model>> GetModel(int id)
        {
            var model = await _unitOfWork.Models.FindAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        // PUT: api/ModelsApiEndpoint/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model model)
        {
            if (id != model.ModelId)
            {
                return BadRequest();
            }

            _unitOfWork.Models.UpdateAsync(model);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/ModelsApiEndpoint
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel([Bind("modelId,Name")] Model model)
        {
            Brand brand = _unitOfWork.Brands.Find(model.Brand.BrandId);
            model.Brand = brand;

            _unitOfWork.Models.Add(model);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetModel", new { id = model.ModelId }, model);
        }

        // DELETE: api/ModelsApiEndpoint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Model>> DeleteModel(int id)
        {
            var model = await _unitOfWork.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.Models.Remove(model);
            await _unitOfWork.CompleteAsync();

            return model;
        }

        [HttpPost("GetModelByBrand/")]
        public JsonResult GetModelsByBrand(int id)
        {
            try
            {
                List<Model> models = _unitOfWork.Models.Where(m => m.Brand.BrandId == id).ToList();

                return new JsonResult(new { ok = true, data = models, message = "ok" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { ok = false, message = ex.Message });
            }
        }

        private bool ModelExists(int id)
        {
            return _unitOfWork.Models.Find(id) != null;
        }
    }
}
