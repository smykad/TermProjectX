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
    public class ObjectClassController : Controller
    {
        private readonly SCPContext _context;

        public ObjectClassController(SCPContext context)
        {
            _context = context;
        }

        // GET: ObjectClass
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObjectClasses.ToListAsync());
        }

        // GET: ObjectClass/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectClass = await _context.ObjectClasses
                .FirstOrDefaultAsync(m => m.ObjectClassId == id);
            if (objectClass == null)
            {
                return NotFound();
            }

            return View(objectClass);
        }

        // GET: ObjectClass/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObjectClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjectClassId,Name")] ObjectClass objectClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objectClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objectClass);
        }

        // GET: ObjectClass/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectClass = await _context.ObjectClasses.FindAsync(id);
            if (objectClass == null)
            {
                return NotFound();
            }
            return View(objectClass);
        }

        // POST: ObjectClass/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ObjectClassId,Name")] ObjectClass objectClass)
        {
            if (id != objectClass.ObjectClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objectClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjectClassExists(objectClass.ObjectClassId))
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
            return View(objectClass);
        }

        // GET: ObjectClass/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectClass = await _context.ObjectClasses
                .FirstOrDefaultAsync(m => m.ObjectClassId == id);
            if (objectClass == null)
            {
                return NotFound();
            }

            return View(objectClass);
        }

        // POST: ObjectClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var objectClass = await _context.ObjectClasses.FindAsync(id);
            _context.ObjectClasses.Remove(objectClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjectClassExists(string id)
        {
            return _context.ObjectClasses.Any(e => e.ObjectClassId == id);
        }
    }
}
