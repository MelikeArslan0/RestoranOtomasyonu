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
    public class yetkilitabloesController : Controller
    {
        private readonly DataContext _context;

        public yetkilitabloesController(DataContext context)
        {
            _context = context;
        }

        // GET: YönetimPaneli/yetkilitabloes
        public async Task<IActionResult> Index()
        {
              return _context.yetkilitablo != null ? 
                          View(await _context.yetkilitablo.ToListAsync()) :
                          Problem("Entity set 'DataContext.yetkilitablo'  is null.");
        }

        // GET: YönetimPaneli/yetkilitabloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.yetkilitablo == null)
            {
                return NotFound();
            }

            var yetkilitablo = await _context.yetkilitablo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yetkilitablo == null)
            {
                return NotFound();
            }

            return View(yetkilitablo);
        }

        // GET: YönetimPaneli/yetkilitabloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YönetimPaneli/yetkilitabloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,KTC,KUnvan,KAdSoyad,KTel")] yetkilitablo yetkilitablo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yetkilitablo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yetkilitablo);
        }

        // GET: YönetimPaneli/yetkilitabloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.yetkilitablo == null)
            {
                return NotFound();
            }

            var yetkilitablo = await _context.yetkilitablo.FindAsync(id);
            if (yetkilitablo == null)
            {
                return NotFound();
            }
            return View(yetkilitablo);
        }

        // POST: YönetimPaneli/yetkilitabloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,KTC,KUnvan,KAdSoyad,KTel")] yetkilitablo yetkilitablo)
        {
            if (id != yetkilitablo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yetkilitablo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!yetkilitabloExists(yetkilitablo.ID))
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
            return View(yetkilitablo);
        }

        // GET: YönetimPaneli/yetkilitabloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.yetkilitablo == null)
            {
                return NotFound();
            }

            var yetkilitablo = await _context.yetkilitablo
                .FirstOrDefaultAsync(m => m.ID == id);
            if (yetkilitablo == null)
            {
                return NotFound();
            }

            return View(yetkilitablo);
        }

        // POST: YönetimPaneli/yetkilitabloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.yetkilitablo == null)
            {
                return Problem("Entity set 'DataContext.yetkilitablo'  is null.");
            }
            var yetkilitablo = await _context.yetkilitablo.FindAsync(id);
            if (yetkilitablo != null)
            {
                _context.yetkilitablo.Remove(yetkilitablo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool yetkilitabloExists(int id)
        {
          return (_context.yetkilitablo?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
