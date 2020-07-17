using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dungeons_And_Flagons.Data;
using Dungeons_And_Flagons.Models;
using Microsoft.AspNetCore.Authorization;

namespace Dungeons_And_Flagons.Controllers
{
    [Authorize]

    public class SourcesController : Controller
    {
        private readonly DafDB _context;

        public SourcesController(DafDB context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Sources
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sources.ToListAsync());
        }

        [AllowAnonymous]
        // GET: Sources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sources = await _context.Sources
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sources == null)
            {
                return NotFound();
            }

            return View(sources);
        }
        [Authorize(Roles = "Administrativo")]

        // GET: Sources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]

        public async Task<IActionResult> Create([Bind("ID,Name,Summary,Permission,Path,Category")] Sources sources)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sources);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sources);
        }
        [Authorize(Roles = "Administrativo")]

        // GET: Sources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sources = await _context.Sources.FindAsync(id);
            if (sources == null)
            {
                return NotFound();
            }
            return View(sources);
        }

        // POST: Sources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]

        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Summary,Permission,Path,Category")] Sources sources)
        {
            if (id != sources.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sources);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SourcesExists(sources.ID))
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
            return View(sources);
        }

        // GET: Sources/Delete/5
        [Authorize(Roles = "Administrativo")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sources = await _context.Sources
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sources == null)
            {
                return NotFound();
            }

            return View(sources);
        }

        // POST: Sources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrativo")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sources = await _context.Sources.FindAsync(id);
            _context.Sources.Remove(sources);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SourcesExists(int id)
        {
            return _context.Sources.Any(e => e.ID == id);
        }
    }
}
