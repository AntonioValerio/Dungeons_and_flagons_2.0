using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dungeons_And_Flagons.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dungeons_And_Flagons.Controllers
{
    public class SubraceSpellController : Controller
    {
        private readonly DafDB _context;

        public SubraceSpellController(DafDB context)
        {
            _context = context;
        }
        // GET: Sources
        public async Task<IActionResult> Index()
        {
            return View(await _context.SubracesSpell.ToListAsync());
        }

    }
}
