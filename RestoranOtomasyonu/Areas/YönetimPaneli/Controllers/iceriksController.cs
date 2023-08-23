using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoranOtomasyonu.DAL;
using RestoranOtomasyonu.Models;

namespace RestoranOtomasyonu.Areas.YönetimPaneli.Controllers
{
    [Area("YönetimPaneli")]
    public class iceriksController : Controller
    {
        private readonly DataContext _context;

        public iceriksController(DataContext context)
        {
            _context = context;
        }

        // GET: YönetimPaneli/iceriks
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.icerik.Include(i => i.urunler);
            return View(await dataContext.ToListAsync());
        }

        // GET: YönetimPaneli/iceriks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.icerik == null)
            {
                return NotFound();
            }

            var icerik = await _context.icerik
                .Include(i => i.urunler)
                .FirstOrDefaultAsync(m => m.IcerikID == id);
            if (icerik == null)
            {
                return NotFound();
            }

            return View(icerik);
        }

        // GET: YönetimPaneli/iceriks/Create
        public IActionResult Create()
        {
            ViewData["urunlerID"] = new SelectList(_context.urunler, "UrunID", "UrunID");
            return View();
        }

        // POST: YönetimPaneli/iceriks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IcerikID,urunlerID,IcerikAD")] icerik icerik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(icerik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["urunlerID"] = new SelectList(_context.urunler, "UrunID", "UrunID", icerik.urunlerID);
            return View(icerik);
        }

        // GET: YönetimPaneli/iceriks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.icerik == null)
            {
                return NotFound();
            }

            var icerik = await _context.icerik.FindAsync(id);
            if (icerik == null)
            {
                return NotFound();
            }
            ViewData["urunlerID"] = new SelectList(_context.urunler, "UrunID", "UrunID", icerik.urunlerID);
            return View(icerik);
        }

        // POST: YönetimPaneli/iceriks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IcerikID,urunlerID,IcerikAD")] icerik icerik)
        {
            if (id != icerik.IcerikID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(icerik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!icerikExists(icerik.IcerikID))
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
            ViewData["urunlerID"] = new SelectList(_context.urunler, "UrunID", "UrunID", icerik.urunlerID);
            return View(icerik);
        }

        // GET: YönetimPaneli/iceriks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.icerik == null)
            {
                return NotFound();
            }

            var icerik = await _context.icerik
                .Include(i => i.urunler)
                .FirstOrDefaultAsync(m => m.IcerikID == id);
            if (icerik == null)
            {
                return NotFound();
            }

            return View(icerik);
        }

        // POST: YönetimPaneli/iceriks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.icerik == null)
            {
                return Problem("Entity set 'DataContext.icerik'  is null.");
            }
            var icerik = await _context.icerik.FindAsync(id);
            if (icerik != null)
            {
                _context.icerik.Remove(icerik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool icerikExists(int id)
        {
          return (_context.icerik?.Any(e => e.IcerikID == id)).GetValueOrDefault();
        }
    }
}
