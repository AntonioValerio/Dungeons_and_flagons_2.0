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
    public class SubracesController : Controller
    {
        private readonly DafDB _context;

        public SubracesController(DafDB context)
        {
            _context = context;
        }

        // GET: Subraces
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subraces.ToListAsync());
        }

        // GET: Subraces/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subraces = await _context.Subraces
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subraces == null)
            {
                return NotFound();
            }

            return View(subraces);
        }

        // GET: Subraces/Create
        

        public IActionResult Create()
        {
            return View();
        }

        // POST: Subraces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        

        public async Task<IActionResult> Create([Bind("ID,MainRace,Name,Description,Features,Spellcasting,Source")] Subraces subraces)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subraces);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subraces);
        }

        // GET: Subraces/Edit/5
        

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subraces = await _context.Subraces.FindAsync(id);
            if (subraces == null)
            {
                return NotFound();
            }
            return View(subraces);
        }

        // POST: Subraces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("ID,MainRace,Name,Description,Features,Spellcasting,Source")] Subraces subraces)
        {
            if (id != subraces.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subraces);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubracesExists(subraces.ID))
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
            return View(subraces);
        }

        // GET: Subraces/Delete/5
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subraces = await _context.Subraces
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subraces == null)
            {
                return NotFound();
            }

            return View(subraces);
        }

        // POST: Subraces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subraces = await _context.Subraces.FindAsync(id);
            _context.Subraces.Remove(subraces);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubracesExists(int id)
        {
            return _context.Subraces.Any(e => e.ID == id);
        }
    }
}
