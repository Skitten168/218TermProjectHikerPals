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
    public class HikersController : Controller
    {
        private readonly HikerContext _context;

        public HikersController(HikerContext context)
        {
            _context = context;
        }

        // GET: Hikers
        /*      public async Task<IActionResult> Index()
              {
                  var hikerContext = _context.Hikers.Include(h => h.Trail).Include(h => h.pack);
                  return View(await hikerContext.ToListAsync());
              }*/

       
        
        
       public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AgeSortParam"] = sortOrder == "Age" ? "age_desc" : "Age";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var hikers = from s in _context.Hikers.Include(s => s.Trail).Include(s => s.pack)
                         select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                hikers = hikers.Where(s => s.TrailName.Contains(searchString));
            }
            
                        
                        switch (sortOrder)
            {
                case "name_desc":
                    hikers = hikers.OrderByDescending(s => s.TrailName);
                    break;
                case "Age":
                    hikers = hikers.OrderBy(s => s.Age);
                    break;
                case "age_desc":
                    hikers = hikers.OrderByDescending(s => s.Age);
                    break;
                default:
                    hikers = hikers.OrderBy(s => s.TrailName);
                    break;

            }
            int pageSize = 3;
            return View(await PaginatedList<Hiker>.CreateAsync(hikers.AsNoTracking(),pageNumber ?? 1, pageSize));
        }


        
        
        
        // GET: Hikers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiker = await _context.Hikers
                .Include(h => h.Trail)
                .Include(h => h.pack)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hiker == null)
            {
                return NotFound();
            }

            return View(hiker);
        }

        // GET: Hikers/Create
        public IActionResult Create()
        {
            ViewData["TrailId"] = new SelectList(_context.Trails, "TrailId", "TName");
            ViewData["PackId"] = new SelectList(_context.pack, "PackId", "PackName");
            return View();
        }

        // POST: Hikers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrailName,Age,AverageDailyMiles,YearsExperience,email,TrailId,PackId, PackName")] Hiker hiker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hiker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrailId"] = new SelectList(_context.Trails, "TrailId", "TName", hiker.TrailId);
            ViewData["PackId"] = new SelectList(_context.pack, "PackId", "PackName", hiker.PackId);
            return View(hiker);
        }

        // GET: Hikers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiker = await _context.Hikers.FindAsync(id);
            if (hiker == null)
            {
                return NotFound();
            }
            ViewData["TrailId"] = new SelectList(_context.Trails, "TrailId", "TName", hiker.TrailId);
            ViewData["PackId"] = new SelectList(_context.pack, "PackId", "PackName", hiker.PackId);
            return View(hiker);
        }

        // POST: Hikers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrailName,Age,AverageDailyMiles,YearsExperience,email,TrailId,PackId,PackName")] Hiker hiker)
        {
            if (id != hiker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hiker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HikerExists(hiker.Id))
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
            ViewData["TrailId"] = new SelectList(_context.Trails, "TrailId", "TName", hiker.TrailId);
            ViewData["PackId"] = new SelectList(_context.pack, "PackId", "PackName", hiker.PackId);
            return View(hiker);
        }

        // GET: Hikers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hiker = await _context.Hikers
                .Include(h => h.Trail)
                .Include(h => h.pack)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hiker == null)
            {
                return NotFound();
            }

            return View(hiker);
        }

        // POST: Hikers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hiker = await _context.Hikers.FindAsync(id);
            _context.Hikers.Remove(hiker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HikerExists(int id)
        {
            return _context.Hikers.Any(e => e.Id == id);
        }
    }
}
