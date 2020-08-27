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
using Microsoft.AspNetCore.Identity;

namespace Dungeons_And_Flagons.Controllers
{

    [Authorize]



    public class SpellsController : Controller
    {
        private readonly DafDB _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SpellsController(DafDB context , UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Spells
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var dafDB = _context.Spells.Include(s => s.Book);
            return View(await dafDB.ToListAsync());
        }

        // GET: Spells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spells = await _context.Spells
                .Include(s => s.Book)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (spells == null)
            {
                return NotFound();
            }

            return View(spells);
        }


        // GET: Spells/Create
        [Authorize(Roles ="Administrator")]
        public IActionResult Create()
        {
            ViewData["Source"] = new SelectList(_context.Sources, "ID", "ID");
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Create([Bind("ID,Name,Level,CastingTime,Range,Components,Duration,School,Description,Source")] Spells spells)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spells);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Source"] = new SelectList(_context.Sources, "ID", "ID", spells.Source);
            return View(spells);
        }


        [Authorize(Roles = "Administrator")]
        // GET: Spells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spells = await _context.Spells.FindAsync(id);
            if (spells == null)
            {
                return NotFound();
            }
            ViewData["Source"] = new SelectList(_context.Sources, "ID", "ID", spells.Source);
            return View(spells);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]

        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Level,CastingTime,Range,Components,Duration,School,Description,Source")] Spells spells)
        {
            if (id != spells.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spells);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellsExists(spells.ID))
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
            ViewData["Source"] = new SelectList(_context.Sources, "ID", "ID", spells.Source);
            return View(spells);
        }


        [Authorize(Roles = "Administrator")]
        // GET: Spells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spells = await _context.Spells
                .Include(s => s.Book)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (spells == null)
            {
                return NotFound();
            }

            return View(spells);
        }
        

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spells = await _context.Spells.FindAsync(id);
            _context.Spells.Remove(spells);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellsExists(int id)
        {
            return _context.Spells.Any(e => e.ID == id);
        }
    }
}
