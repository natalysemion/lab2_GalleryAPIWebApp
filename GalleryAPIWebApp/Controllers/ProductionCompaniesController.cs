using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GalleryAPIWebApp.Models;

namespace GalleryAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionCompaniesController : ControllerBase
    {
        private readonly GalleryAPIContext _context;

        public ProductionCompaniesController(GalleryAPIContext context)
        {
            _context = context;
        }

        // GET: api/ProductionCompanies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductionCompany>>> GetProductionCompanies()
        {
          if (_context.ProductionCompanies == null)
          {
              return NotFound();
          }
            return await _context.ProductionCompanies.ToListAsync();
        }

        // GET: api/ProductionCompanies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductionCompany>> GetProductionCompany(int id)
        {
          if (_context.ProductionCompanies == null)
          {
              return NotFound();
          }
            var productionCompany = await _context.ProductionCompanies.FindAsync(id);

            if (productionCompany == null)
            {
                return NotFound();
            }

            return productionCompany;
        }

        // PUT: api/ProductionCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductionCompany(int id, ProductionCompany productionCompany)
        {
            if (id != productionCompany.Id)
            {
                return BadRequest();
            }

            _context.Entry(productionCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionCompanyExists(id))
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

        // POST: api/ProductionCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductionCompany>> PostProductionCompany(ProductionCompany productionCompany)
        {
          if (_context.ProductionCompanies == null)
          {
              return Problem("Entity set 'GalleryAPIContext.ProductionCompanies'  is null.");
          }
            _context.ProductionCompanies.Add(productionCompany);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductionCompany", new { id = productionCompany.Id }, productionCompany);
        }

        // DELETE: api/ProductionCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductionCompany(int id)
        {
            if (_context.ProductionCompanies == null)
            {
                return NotFound();
            }
            var productionCompany = await _context.ProductionCompanies.FindAsync(id);
            if (productionCompany == null)
            {
                return NotFound();
            }

            _context.ProductionCompanies.Remove(productionCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductionCompanyExists(int id)
        {
            return (_context.ProductionCompanies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
