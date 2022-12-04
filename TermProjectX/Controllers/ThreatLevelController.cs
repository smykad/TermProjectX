using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProjectX.Models;

namespace TermProjectX.Controllers
{
    public class ThreatLevelController : Controller
    {
        private readonly SCPContext _context;

        public ThreatLevelController(SCPContext context)
        {
            _context = context;
        }

        // GET: ThreatLevel
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThreatLevels.ToListAsync());
        }

        // GET: ThreatLevel/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threatLevel = await _context.ThreatLevels
                .FirstOrDefaultAsync(m => m.ThreatLevelId == id);
            if (threatLevel == null)
            {
                return NotFound();
            }

            return View(threatLevel);
        }

        // GET: ThreatLevel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThreatLevel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThreatLevelId,Name")] ThreatLevel threatLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(threatLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(threatLevel);
        }

        // GET: ThreatLevel/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threatLevel = await _context.ThreatLevels.FindAsync(id);
            if (threatLevel == null)
            {
                return NotFound();
            }
            return View(threatLevel);
        }

        // POST: ThreatLevel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ThreatLevelId,Name")] ThreatLevel threatLevel)
        {
            if (id != threatLevel.ThreatLevelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(threatLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThreatLevelExists(threatLevel.ThreatLevelId))
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
            return View(threatLevel);
        }

        // GET: ThreatLevel/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var threatLevel = await _context.ThreatLevels
                .FirstOrDefaultAsync(m => m.ThreatLevelId == id);
            if (threatLevel == null)
            {
                return NotFound();
            }

            return View(threatLevel);
        }

        // POST: ThreatLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var threatLevel = await _context.ThreatLevels.FindAsync(id);
            _context.ThreatLevels.Remove(threatLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThreatLevelExists(string id)
        {
            return _context.ThreatLevels.Any(e => e.ThreatLevelId == id);
        }
    }
}
