using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoranOtomasyonu.DAL;
using RestoranOtomasyonu.ViewModels;

namespace RestoranOtomasyonu.Areas.YönetimPaneli.Controllers
{
    [Authorize]
    [Area("YönetimPaneli")]
    public class masaayirsController : Controller
    {
        private readonly DataContext _context;

        public masaayirsController(DataContext context)
        {
            _context = context;
        }

        // GET: YönetimPaneli/masaayirs
        public async Task<IActionResult> Index()
        {
              return _context.RezervasyonOlusturViewModel != null ? 
                          View(await _context.RezervasyonOlusturViewModel.ToListAsync()) :
                          Problem("Entity set 'DataContext.RezervasyonOlusturViewModel'  is null.");
        }

        // GET: YönetimPaneli/masaayirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RezervasyonOlusturViewModel == null)
            {
                return NotFound();
            }

            var rezervasyonOlusturViewModel = await _context.RezervasyonOlusturViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervasyonOlusturViewModel == null)
            {
                return NotFound();
            }

            return View(rezervasyonOlusturViewModel);
        }

        // GET: YönetimPaneli/masaayirs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YönetimPaneli/masaayirs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Isim,Soyisim,Telefon,Kisi,Tarih")] RezervasyonOlusturViewModel rezervasyonOlusturViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervasyonOlusturViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezervasyonOlusturViewModel);
        }

        // GET: YönetimPaneli/masaayirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RezervasyonOlusturViewModel == null)
            {
                return NotFound();
            }

            var rezervasyonOlusturViewModel = await _context.RezervasyonOlusturViewModel.FindAsync(id);
            if (rezervasyonOlusturViewModel == null)
            {
                return NotFound();
            }
            return View(rezervasyonOlusturViewModel);
        }

        // POST: YönetimPaneli/masaayirs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Isim,Soyisim,Telefon,Kisi,Tarih")] RezervasyonOlusturViewModel rezervasyonOlusturViewModel)
        {
            if (id != rezervasyonOlusturViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervasyonOlusturViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervasyonOlusturViewModelExists(rezervasyonOlusturViewModel.Id))
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
            return View(rezervasyonOlusturViewModel);
        }

        // GET: YönetimPaneli/masaayirs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RezervasyonOlusturViewModel == null)
            {
                return NotFound();
            }

            var rezervasyonOlusturViewModel = await _context.RezervasyonOlusturViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervasyonOlusturViewModel == null)
            {
                return NotFound();
            }

            return View(rezervasyonOlusturViewModel);
        }

        // POST: YönetimPaneli/masaayirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RezervasyonOlusturViewModel == null)
            {
                return Problem("Entity set 'DataContext.RezervasyonOlusturViewModel'  is null.");
            }
            var rezervasyonOlusturViewModel = await _context.RezervasyonOlusturViewModel.FindAsync(id);
            if (rezervasyonOlusturViewModel != null)
            {
                _context.RezervasyonOlusturViewModel.Remove(rezervasyonOlusturViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervasyonOlusturViewModelExists(int id)
        {
          return (_context.RezervasyonOlusturViewModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
