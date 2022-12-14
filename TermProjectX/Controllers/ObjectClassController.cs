using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ObjectClasses.ToListAsync());
        }

        // GET: ObjectClass/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObjectClass/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjectClassId,Name,Description")] ObjectClass objectClass)
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
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("ObjectClassId,Name,Description")] ObjectClass objectClass)
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
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var objectClass = await _context.ObjectClasses.FindAsync(id);
            _context.ObjectClasses.Remove(objectClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjectClassExists(int id)
        {
            return _context.ObjectClasses.Any(e => e.ObjectClassId == id);
        }
    }
}
