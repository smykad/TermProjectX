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
    public class SCPController : Controller
    {
        private readonly SCPContext _context;

        public SCPController(SCPContext context)
        {
            _context = context;
        }

        // GET: SCP
        public async Task<IActionResult> Index()
        {
            var sCPContext = _context.SCPs.Include(s => s.ObjectClass).Include(s => s.ThreatLevel);
            return View(await sCPContext.ToListAsync());
        }

        // GET: SCP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sCP = await _context.SCPs
                .Include(s => s.ObjectClass)
                .Include(s => s.ThreatLevel)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sCP == null)
            {
                return NotFound();
            }

            return View(sCP);
        }

        // GET: SCP/Create
        public IActionResult Create()
        {
            ViewData["ObjectClassID"] = new SelectList(_context.ObjectClasses, "ObjectClassId", "ObjectClassId");
            ViewData["ThreatLevelID"] = new SelectList(_context.ThreatLevels, "ThreatLevelId", "ThreatLevelId");
            return View();
        }

        // POST: SCP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Containment,ObjectClassID,ThreatLevelID")] SCP sCP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sCP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ObjectClassID"] = new SelectList(_context.ObjectClasses, "ObjectClassId", "ObjectClassId", sCP.ObjectClassID);
            ViewData["ThreatLevelID"] = new SelectList(_context.ThreatLevels, "ThreatLevelId", "ThreatLevelId", sCP.ThreatLevelID);
            return View(sCP);
        }

        // GET: SCP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sCP = await _context.SCPs.FindAsync(id);
            if (sCP == null)
            {
                return NotFound();
            }
            ViewData["ObjectClassID"] = new SelectList(_context.ObjectClasses, "ObjectClassId", "ObjectClassId", sCP.ObjectClassID);
            ViewData["ThreatLevelID"] = new SelectList(_context.ThreatLevels, "ThreatLevelId", "ThreatLevelId", sCP.ThreatLevelID);
            return View(sCP);
        }

        // POST: SCP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,Containment,ObjectClassID,ThreatLevelID")] SCP sCP)
        {
            if (id != sCP.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sCP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SCPExists(sCP.ID))
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
            ViewData["ObjectClassID"] = new SelectList(_context.ObjectClasses, "ObjectClassId", "ObjectClassId", sCP.ObjectClassID);
            ViewData["ThreatLevelID"] = new SelectList(_context.ThreatLevels, "ThreatLevelId", "ThreatLevelId", sCP.ThreatLevelID);
            return View(sCP);
        }

        // GET: SCP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sCP = await _context.SCPs
                .Include(s => s.ObjectClass)
                .Include(s => s.ThreatLevel)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sCP == null)
            {
                return NotFound();
            }

            return View(sCP);
        }

        // POST: SCP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sCP = await _context.SCPs.FindAsync(id);
            _context.SCPs.Remove(sCP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SCPExists(int id)
        {
            return _context.SCPs.Any(e => e.ID == id);
        }
    }
}
