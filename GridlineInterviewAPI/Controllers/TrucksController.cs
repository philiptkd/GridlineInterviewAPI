﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GridlineInterviewAPI.Core.Models;
using GridlineInterviewAPI.DAL;

namespace GridlineInterviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrucksController : ControllerBase
    {
        private readonly GridlineContext _context;

        public TrucksController(GridlineContext context)
        {
            _context = context;
        }

        // GET: api/Trucks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Truck>>> GetTrucks()
        {
          if (_context.Trucks == null)
          {
              return NotFound();
          }
            return await _context.Trucks.Include(x => x.Drivers).ToListAsync();
        }

        // GET: api/Trucks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Truck>> GetTruck(int id)
        {
          if (_context.Trucks == null)
          {
              return NotFound();
          }
            var truck = await _context.Trucks
                .Include(x => x.Drivers)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (truck == null)
            {
                return NotFound();
            }

            return truck;
        }

        // PUT: api/Trucks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruck(int id, Truck truck)
        {
            if (id != truck.Id)
            {
                return BadRequest();
            }

            _context.Entry(truck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TruckExists(id))
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

        // POST: api/Trucks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Truck>> PostTruck(Truck truck)
        {
          if (_context.Trucks == null)
          {
              return Problem("Entity set 'GridlineContext.Trucks'  is null.");
          }
            _context.Trucks.Add(truck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTruck", new { id = truck.Id }, truck);
        }

        // DELETE: api/Trucks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruck(int id)
        {
            if (_context.Trucks == null)
            {
                return NotFound();
            }
            var truck = await _context.Trucks.FindAsync(id);
            if (truck == null)
            {
                return NotFound();
            }

            _context.Trucks.Remove(truck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TruckExists(int id)
        {
            return (_context.Trucks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
