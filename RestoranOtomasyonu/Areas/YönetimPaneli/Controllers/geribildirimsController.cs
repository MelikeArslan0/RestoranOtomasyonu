using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoranOtomasyonu.DAL;
using RestoranOtomasyonu.Models;

namespace RestoranOtomasyonu.Areas.YönetimPaneli.Controllers
{
    [Authorize]
    [Area("YönetimPaneli")]
    public class geribildirimsController : Controller
    {
        private readonly DataContext _context;

        public geribildirimsController(DataContext context)
        {
            _context = context;
        }

        // GET: YönetimPaneli/geribildirims
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.geribildirim.Include(g => g.musteri);
            return View(await dataContext.ToListAsync());
        }

        // GET: YönetimPaneli/geribildirims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.geribildirim == null)
            {
                return NotFound();
            }

            var geribildirim = await _context.geribildirim
                .Include(g => g.musteri)
                .FirstOrDefaultAsync(m => m.GID == id);
            if (geribildirim == null)
            {
                return NotFound();
            }

            return View(geribildirim);
        }

        // GET: YönetimPaneli/geribildirims/Create
        public IActionResult Create()
        {
            ViewData["MusteriID"] = new SelectList(_context.musteri, "MusteriID", "MusteriID");
            return View();
        }

        // POST: YönetimPaneli/geribildirims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GID,MusteriID,Aciklama,YildizPuan")] geribildirim geribildirim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geribildirim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MusteriID"] = new SelectList(_context.musteri, "MusteriID", "MusteriID", geribildirim.MusteriID);
            return View(geribildirim);
        }

        // GET: YönetimPaneli/geribildirims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.geribildirim == null)
            {
                return NotFound();
            }

            var geribildirim = await _context.geribildirim.FindAsync(id);
            if (geribildirim == null)
            {
                return NotFound();
            }
            ViewData["MusteriID"] = new SelectList(_context.musteri, "MusteriID", "MusteriID", geribildirim.MusteriID);
            return View(geribildirim);
        }

        // POST: YönetimPaneli/geribildirims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GID,MusteriID,Aciklama,YildizPuan")] geribildirim geribildirim)
        {
            if (id != geribildirim.GID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(geribildirim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!geribildirimExists(geribildirim.GID))
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
            ViewData["MusteriID"] = new SelectList(_context.musteri, "MusteriID", "MusteriID", geribildirim.MusteriID);
            return View(geribildirim);
        }

        // GET: YönetimPaneli/geribildirims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.geribildirim == null)
            {
                return NotFound();
            }

            var geribildirim = await _context.geribildirim
                .Include(g => g.musteri)
                .FirstOrDefaultAsync(m => m.GID == id);
            if (geribildirim == null)
            {
                return NotFound();
            }

            return View(geribildirim);
        }

        // POST: YönetimPaneli/geribildirims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.geribildirim == null)
            {
                return Problem("Entity set 'DataContext.geribildirim'  is null.");
            }
            var geribildirim = await _context.geribildirim.FindAsync(id);
            if (geribildirim != null)
            {
                _context.geribildirim.Remove(geribildirim);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool geribildirimExists(int id)
        {
          return (_context.geribildirim?.Any(e => e.GID == id)).GetValueOrDefault();
        }
    }
}
