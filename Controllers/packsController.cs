using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HikerPals.Models;

namespace HikerPals.Controllers
{
    public class packsController : Controller
    {
        private readonly HikerContext _context;

        public packsController(HikerContext context)
        {
            _context = context;
        }

        // GET: packs
        public async Task<IActionResult> Index()
        {
            return View(await _context.pack.ToListAsync());
        }

        // GET: packs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pack = await _context.pack
                .FirstOrDefaultAsync(m => m.PackId == id);
            if (pack == null)
            {
                return NotFound();
            }

            return View(pack);
        }

        // GET: packs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: packs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackId,PackName,PackVolume")] pack pack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pack);
        }

        // GET: packs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pack = await _context.pack.FindAsync(id);
            if (pack == null)
            {
                return NotFound();
            }
            return View(pack);
        }

        // POST: packs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackId,PackName,PackVolume")] pack pack)
        {
            if (id != pack.PackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!packExists(pack.PackId))
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
            return View(pack);
        }

        // GET: packs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pack = await _context.pack
                .FirstOrDefaultAsync(m => m.PackId == id);
            if (pack == null)
            {
                return NotFound();
            }

            return View(pack);
        }

        // POST: packs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pack = await _context.pack.FindAsync(id);
            _context.pack.Remove(pack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool packExists(int id)
        {
            return _context.pack.Any(e => e.PackId == id);
        }
    }
}
