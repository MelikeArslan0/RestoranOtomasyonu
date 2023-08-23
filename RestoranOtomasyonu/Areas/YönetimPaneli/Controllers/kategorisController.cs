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
    public class kategorisController : Controller
    {
        private readonly DataContext _context;

        public kategorisController(DataContext context)
        {
            _context = context;
        }

        // GET: YönetimPaneli/kategoris
        public async Task<IActionResult> Index()
        {
              return _context.kategori != null ? 
                          View(await _context.kategori.ToListAsync()) :
                          Problem("Entity set 'DataContext.kategori'  is null.");
        }

        // GET: YönetimPaneli/kategoris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.kategori == null)
            {
                return NotFound();
            }

            var kategori = await _context.kategori
                .FirstOrDefaultAsync(m => m.KategoriID == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // GET: YönetimPaneli/kategoris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YönetimPaneli/kategoris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriID,KategoriAd")] kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategori);
        }

        // GET: YönetimPaneli/kategoris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.kategori == null)
            {
                return NotFound();
            }

            var kategori = await _context.kategori.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        // POST: YönetimPaneli/kategoris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KategoriID,KategoriAd")] kategori kategori)
        {
            if (id != kategori.KategoriID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!kategoriExists(kategori.KategoriID))
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
            return View(kategori);
        }

        // GET: YönetimPaneli/kategoris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.kategori == null)
            {
                return NotFound();
            }

            var kategori = await _context.kategori
                .FirstOrDefaultAsync(m => m.KategoriID == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // POST: YönetimPaneli/kategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.kategori == null)
            {
                return Problem("Entity set 'DataContext.kategori'  is null.");
            }
            var kategori = await _context.kategori.FindAsync(id);
            if (kategori != null)
            {
                _context.kategori.Remove(kategori);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool kategoriExists(int id)
        {
          return (_context.kategori?.Any(e => e.KategoriID == id)).GetValueOrDefault();
        }
    }
}
