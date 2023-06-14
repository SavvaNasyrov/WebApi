using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class OccurrencesDatasController : Controller
    {
        private readonly WebApiContext _context;

        public OccurrencesDatasController(WebApiContext context)
        {
            _context = context;
        }

        // GET: OccurrencesDatas
        public async Task<IActionResult> Index()
        {
              return _context.OccurrencesData != null ? 
                          View(await _context.OccurrencesData.ToListAsync()) :
                          Problem("Entity set 'WebApiContext.OccurrencesData'  is null.");
        }

        // GET: OccurrencesDatas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.OccurrencesData == null)
            {
                return NotFound();
            }

            var occurrencesData = await _context.OccurrencesData
                .FirstOrDefaultAsync(m => m.OwnerID == id);
            if (occurrencesData == null)
            {
                return NotFound();
            }

            return View(occurrencesData);
        }

        // GET: OccurrencesDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OccurrencesDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OwnerID,JsonString")] OccurrencesData occurrencesData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(occurrencesData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(occurrencesData);
        }

        // GET: OccurrencesDatas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.OccurrencesData == null)
            {
                return NotFound();
            }

            var occurrencesData = await _context.OccurrencesData.FindAsync(id);
            if (occurrencesData == null)
            {
                return NotFound();
            }
            return View(occurrencesData);
        }

        // POST: OccurrencesDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OwnerID,JsonString")] OccurrencesData occurrencesData)
        {
            if (id != occurrencesData.OwnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(occurrencesData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OccurrencesDataExists(occurrencesData.OwnerID))
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
            return View(occurrencesData);
        }

        // GET: OccurrencesDatas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.OccurrencesData == null)
            {
                return NotFound();
            }

            var occurrencesData = await _context.OccurrencesData
                .FirstOrDefaultAsync(m => m.OwnerID == id);
            if (occurrencesData == null)
            {
                return NotFound();
            }

            return View(occurrencesData);
        }

        // POST: OccurrencesDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.OccurrencesData == null)
            {
                return Problem("Entity set 'WebApiContext.OccurrencesData'  is null.");
            }
            var occurrencesData = await _context.OccurrencesData.FindAsync(id);
            if (occurrencesData != null)
            {
                _context.OccurrencesData.Remove(occurrencesData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OccurrencesDataExists(string id)
        {
          return (_context.OccurrencesData?.Any(e => e.OwnerID == id)).GetValueOrDefault();
        }
    }
}
