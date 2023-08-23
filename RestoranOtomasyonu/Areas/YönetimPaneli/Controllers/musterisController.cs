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
    public class musterisController : Controller
    {
        private readonly DataContext _context;

        public musterisController(DataContext context)
        {
            _context = context;
        }

        // GET: YönetimPaneli/musteris
        public async Task<IActionResult> Index()
        {
              return _context.musteri != null ? 
                          View(await _context.musteri.ToListAsync()) :
                          Problem("Entity set 'DataContext.musteri'  is null.");
        }

        // GET: YönetimPaneli/musteris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.musteri == null)
            {
                return NotFound();
            }

            var musteri = await _context.musteri
                .FirstOrDefaultAsync(m => m.MusteriID == id);
            if (musteri == null)
            {
                return NotFound();
            }

            return View(musteri);
        }

        // GET: YönetimPaneli/musteris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YönetimPaneli/musteris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusteriID,Ad,Soyad,Telefon,Daimi,Puan,Mail")] musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musteri);
        }

        // GET: YönetimPaneli/musteris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.musteri == null)
            {
                return NotFound();
            }

            var musteri = await _context.musteri.FindAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            return View(musteri);
        }

        // POST: YönetimPaneli/musteris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusteriID,Ad,Soyad,Telefon,Daimi,Puan,Mail")] musteri musteri)
        {
            if (id != musteri.MusteriID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musteri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!musteriExists(musteri.MusteriID))
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
            return View(musteri);
        }

        // GET: YönetimPaneli/musteris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.musteri == null)
            {
                return NotFound();
            }

            var musteri = await _context.musteri
                .FirstOrDefaultAsync(m => m.MusteriID == id);
            if (musteri == null)
            {
                return NotFound();
            }

            return View(musteri);
        }

        // POST: YönetimPaneli/musteris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.musteri == null)
            {
                return Problem("Entity set 'DataContext.musteri'  is null.");
            }
            var musteri = await _context.musteri.FindAsync(id);
            if (musteri != null)
            {
                _context.musteri.Remove(musteri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool musteriExists(int id)
        {
          return (_context.musteri?.Any(e => e.MusteriID == id)).GetValueOrDefault();
        }
    }
}
