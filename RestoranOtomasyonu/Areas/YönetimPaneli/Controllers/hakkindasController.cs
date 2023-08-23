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
    public class hakkindasController : Controller
    {
        private readonly DataContext _context;

        public hakkindasController(DataContext context)
        {
            _context = context;
        }

        // GET: YönetimPaneli/hakkindas
        public async Task<IActionResult> Index()
        {
              return _context.hakkinda != null ? 
                          View(await _context.hakkinda.ToListAsync()) :
                          Problem("Entity set 'DataContext.hakkinda'  is null.");
        }

        // GET: YönetimPaneli/hakkindas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.hakkinda == null)
            {
                return NotFound();
            }

            var hakkinda = await _context.hakkinda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hakkinda == null)
            {
                return NotFound();
            }

            return View(hakkinda);
        }

        // GET: YönetimPaneli/hakkindas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YönetimPaneli/hakkindas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Aciklama")] hakkinda hakkinda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hakkinda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hakkinda);
        }

        // GET: YönetimPaneli/hakkindas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.hakkinda == null)
            {
                return NotFound();
            }

            var hakkinda = await _context.hakkinda.FindAsync(id);
            if (hakkinda == null)
            {
                return NotFound();
            }
            return View(hakkinda);
        }

        // POST: YönetimPaneli/hakkindas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama")] hakkinda hakkinda)
        {
            if (id != hakkinda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hakkinda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hakkindaExists(hakkinda.Id))
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
            return View(hakkinda);
        }

        // GET: YönetimPaneli/hakkindas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.hakkinda == null)
            {
                return NotFound();
            }

            var hakkinda = await _context.hakkinda
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hakkinda == null)
            {
                return NotFound();
            }

            return View(hakkinda);
        }

        // POST: YönetimPaneli/hakkindas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.hakkinda == null)
            {
                return Problem("Entity set 'DataContext.hakkinda'  is null.");
            }
            var hakkinda = await _context.hakkinda.FindAsync(id);
            if (hakkinda != null)
            {
                _context.hakkinda.Remove(hakkinda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool hakkindaExists(int id)
        {
          return (_context.hakkinda?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
