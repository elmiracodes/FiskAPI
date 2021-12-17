using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FiskAPI.Models;

namespace FiskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FisksController : ControllerBase
    {
        private readonly FiskContext _context;

        public FisksController(FiskContext context)
        {
            _context = context;
        }

        // GET: api/Fisks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fisk>>> GetFisks()
        {
            return await _context.Fisks.ToListAsync();
        }

        // GET: api/Fisks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fisk>> GetFisk(int id)
        {
            var fisk = await _context.Fisks.FindAsync(id);

            if (fisk == null)
            {
                return NotFound();
            }

            // TRY CATCH REDIRECTING TO ERROR PAGE /EnFulErrorSida 
            try
            {
                 return fisk;
            }
            catch (Exception)
            {
                return RedirectToAction("EnFulErrorSida");
            }

           
        }

        // PUT: api/Fisks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFisk(int id, Fisk fisk)
        {
            if (id != fisk.FiskId)
            {
                return BadRequest();
            }

            _context.Entry(fisk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiskExists(id))
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

        // POST: api/Fisks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fisk>> PostFisk(Fisk fisk)
        {
            _context.Fisks.Add(fisk);


            await _context.SaveChangesAsync();
           
            {
                return CreatedAtAction("GetFisk", new { id = fisk.FiskId }, fisk);  
            }
            
           
        }

        // DELETE: api/Fisks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFisk(int id)
        {
            var fisk = await _context.Fisks.FindAsync(id);
            if (fisk == null)
            {
                return NotFound();
            }

            _context.Fisks.Remove(fisk);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FiskExists(int id)
        {
            return _context.Fisks.Any(e => e.FiskId == id);
        }
    }
}
