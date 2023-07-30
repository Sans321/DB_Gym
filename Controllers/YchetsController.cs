using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasseinProekt.Models;
using BasseinProekta.Models;

namespace BasseinProekta.Controllers
{
    public class YchetsController : Controller
    {
        private readonly BasseinContext _context;

        public YchetsController(BasseinContext context)
        {
            _context = context;
        }

        // GET: Ychets
        public async Task<IActionResult> Index()
        {
            var basseinContext = _context.Ychets.Include(y => y.KartaKlienta);
            return View(await basseinContext.ToListAsync());
        }

        // GET: Ychets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ychet = await _context.Ychets
                .Include(y => y.KartaKlienta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ychet == null)
            {
                return NotFound();
            }

            return View(ychet);
        }

        // GET: Ychets/Create
        public IActionResult Create()
        {
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "Id");
            return View();
        }

        // POST: Ychets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Balance,KartaKlientaID")] Ychet ychet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ychet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "Id", ychet.KartaKlientaID);
            return View(ychet);
        }

        // GET: Ychets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ychet = await _context.Ychets.FindAsync(id);
            if (ychet == null)
            {
                return NotFound();
            }
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "Id", ychet.KartaKlientaID);
            return View(ychet);
        }

        // POST: Ychets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Balance,KartaKlientaID")] Ychet ychet)
        {
            if (id != ychet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ychet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YchetExists(ychet.Id))
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
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "Id", ychet.KartaKlientaID);
            return View(ychet);
        }

        // GET: Ychets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ychet = await _context.Ychets
                .Include(y => y.KartaKlienta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ychet == null)
            {
                return NotFound();
            }

            return View(ychet);
        }

        // POST: Ychets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ychet = await _context.Ychets.FindAsync(id);
            _context.Ychets.Remove(ychet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YchetExists(int id)
        {
            return _context.Ychets.Any(e => e.Id == id);
        }
    }
}
