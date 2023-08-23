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
    public class urunlersController : Controller
    {
        private readonly DataContext _context;

        public urunlersController(DataContext context)
        {
            _context = context;
        }

        // GET: YönetimPaneli/urunlers
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.urunler.Include(u => u.kategori);
            return View(await dataContext.ToListAsync());
        }

        // GET: YönetimPaneli/urunlers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.urunler == null)
            {
                return NotFound();
            }

            var urunler = await _context.urunler
                .Include(u => u.kategori)
                .FirstOrDefaultAsync(m => m.UrunID == id);
            if (urunler == null)
            {
                return NotFound();
            }

            return View(urunler);
        }

        // GET: YönetimPaneli/urunlers/Create
        public IActionResult Create()
        {
            ViewData["KategoriList"] = new SelectList(_context.kategori, "KategoriID", "KategoriAd");
            return View();
        }

        // POST: YönetimPaneli/urunlers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UrunID,KategoriID,UrunAD,UrunFiyat,ResimYap,puandurum,Puan")] urunler urunler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urunler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriID"] = new SelectList(_context.kategori, "KategoriID", "KategoriAd", urunler.KategoriID); // "KategoriAd" olarak değiştirildi
            return View(urunler);
        }


        // GET: YönetimPaneli/urunlers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.urunler == null)
            {
                return NotFound();
            }

            var urunler = await _context.urunler.FindAsync(id);
            if (urunler == null)
            {
                return NotFound();
            }
            ViewData["KategoriID"] = new SelectList(_context.kategori, "KategoriID", "KategoriID", urunler.KategoriID);
            return View(urunler);
        }

        // POST: YönetimPaneli/urunlers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UrunID,KategoriID,UrunAD,UrunFiyat,ResimYap,puandurum,Puan")] urunler urunler)
        {
            if (id != urunler.UrunID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urunler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!urunlerExists(urunler.UrunID))
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
            ViewData["KategoriID"] = new SelectList(_context.kategori, "KategoriID", "KategoriID", urunler.KategoriID);
            return View(urunler);
        }

        // GET: YönetimPaneli/urunlers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.urunler == null)
            {
                return NotFound();
            }

            var urunler = await _context.urunler
                .Include(u => u.kategori)
                .FirstOrDefaultAsync(m => m.UrunID == id);
            if (urunler == null)
            {
                return NotFound();
            }

            return View(urunler);
        }

        // POST: YönetimPaneli/urunlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.urunler == null)
            {
                return Problem("Entity set 'DataContext.urunler'  is null.");
            }
            var urunler = await _context.urunler.FindAsync(id);
            if (urunler != null)
            {
                _context.urunler.Remove(urunler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool urunlerExists(int id)
        {
          return (_context.urunler?.Any(e => e.UrunID == id)).GetValueOrDefault();
        }
    }
}
