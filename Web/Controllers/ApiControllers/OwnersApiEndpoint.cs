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
    public class OwnersApiEndpoint : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnersApiEndpoint(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/OwnersApiEndpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetOwners()
        {
            var owners = await _unitOfWork.Owners.GetAllAsync();
            if (owners == null)
            {
                return NotFound();
            }
            return Ok(owners);
        }

        // GET: api/OwnersApiEndpoint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
            var owner = await _unitOfWork.Owners.FindAsync(id);

            if (owner == null)
            {
                return NotFound();
            }

            return owner;
        }

        // PUT: api/OwnersApiEndpoint/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Owner>> PutOwner(int id, [FromBody] Owner owner)
        {
            if (id != owner.OwnerId)
            {
                return BadRequest();
            }

            _unitOfWork.Owners.UpdateAsync(owner);

            try
            {
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            owner = await _unitOfWork.Owners.FindAsync(id);

            return Ok(owner);
        }

        // POST: api/OwnersApiEndpoint
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            _unitOfWork.Owners.Add(owner);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetOwner", new { id = owner.OwnerId }, owner);
        }

        // DELETE: api/OwnersApiEndpoint/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Owner>> DeleteOwner(int id)
        {
            var owner = await _unitOfWork.Owners.FindAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            _unitOfWork.Owners.Remove(owner);
            await _unitOfWork.CompleteAsync();

            return owner;
        }

        private bool OwnerExists(int id)
        {
            return _unitOfWork.Owners.Find(id) != null;
        }
    }
}
