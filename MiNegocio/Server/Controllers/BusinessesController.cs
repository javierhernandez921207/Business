﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiNegocio.Server.Data;
using MiNegocio.Shared.Models;

namespace MiNegocio.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BusinessesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BusinessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Businesses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Business>>> GetBusinesss()
        {
          if (_context.Businesss == null)
          {
              return NotFound();
          }
            return await _context.Businesss.ToListAsync();
        }

        // GET: api/Businesses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Business>> GetBusiness(Guid id)
        {
          if (_context.Businesss == null)
          {
              return NotFound();
          }
            var business = await _context.Businesss.FindAsync(id);

            if (business == null)
            {
                return NotFound();
            }

            return business;
        }

        // PUT: api/Businesses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusiness(Guid id, Business business)
        {
            if (id != business.Id)
            {
                return BadRequest();
            }

            _context.Entry(business).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessExists(id))
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

        // POST: api/Businesses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Business>> PostBusiness(Business business)
        {
          if (_context.Businesss == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Businesss'  is null.");
          }
            _context.Businesss.Add(business);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusiness", new { id = business.Id }, business);
        }

        // DELETE: api/Businesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(Guid id)
        {
            if (_context.Businesss == null)
            {
                return NotFound();
            }
            var business = await _context.Businesss.FindAsync(id);
            if (business == null)
            {
                return NotFound();
            }

            _context.Businesss.Remove(business);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool BusinessExists(Guid id)
        {
            return (_context.Businesss?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
