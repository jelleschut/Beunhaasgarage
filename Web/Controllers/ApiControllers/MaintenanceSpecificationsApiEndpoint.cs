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
    public class MaintenanceSpecificationsApiEndpoint : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MaintenanceSpecificationsApiEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/MaintenanceSpecificationsApiEndpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaintenanceSpecification>>> GetMaintenanceSpecifications()
        {
            var ms = await _unitOfWork.MaintenanceSpecifications.GetAllAsync();
            if (ms == null)
            {
                return NotFound();
            }
            return Ok(ms);
        }

        // GET: api/MaintenanceSpecificationsApiEndpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceSpecification>> GetMaintenanceSpecification(int id)
        {
            var ms = await _unitOfWork.MaintenanceSpecifications.FindAsync(id);

            if (ms == null)
            {
                return NotFound();
            }

            return ms;
        }

        // PUT: api/MaintenanceSpecificationsApiEndpoint/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaintenanceSpecification(int id, MaintenanceSpecification ms)
        {
            if (id != ms.MaintenanceSpecificationId)
            {
                return BadRequest();
            }

            _unitOfWork.MaintenanceSpecifications.UpdateAsync(ms);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceSpecificationExists(id))
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

        [HttpPut("Description/{id}")]
        public async Task<IActionResult> PutMaintenanceSpecification(int id, [FromBody] string description)
        {
            MaintenanceSpecification ms = _unitOfWork.MaintenanceSpecifications.Find(id);

            if (description == ms.Description)
            {
                return NoContent();
            }

            ms.Description = description;

            _unitOfWork.MaintenanceSpecifications.UpdateAsync(ms);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaintenanceSpecificationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(ms);
        }

        // POST: api/MaintenanceSpecificationsApiEndpoint
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MaintenanceSpecification>> PostMaintenanceSpecification(MaintenanceSpecification ms)
        {
            _unitOfWork.MaintenanceSpecifications.Add(ms);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetMaintenanceSpecification", new { id = ms.MaintenanceSpecificationId }, ms);
        }

        // DELETE: api/MaintenanceSpecificationsApiEndpoint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaintenanceSpecification>> DeleteMaintenanceSpecification(int id)
        {
            var ms = await _unitOfWork.MaintenanceSpecifications.FindAsync(id);
            if (ms == null)
            {
                return NotFound();
            }

            _unitOfWork.MaintenanceSpecifications.Remove(ms);
            await _unitOfWork.CompleteAsync();

            return ms;
        }

        private bool MaintenanceSpecificationExists(int id)
        {
            return _unitOfWork.MaintenanceSpecifications.Find(id) != null;
        }
    }
}
