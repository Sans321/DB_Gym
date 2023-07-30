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
    public class RaspisaniesController : Controller
    {
        private readonly BasseinContext _context;

        public RaspisaniesController(BasseinContext context)
        {
            _context = context;
        }

        // GET: Raspisanies
        public async Task<IActionResult> Index()
        {
            var basseinContext = _context.Raspisanies.Include(r => r.KartaKlienta).Include(r => r.Trener).Include(r => r.Vanna);
            return View(await basseinContext.ToListAsync());
        }

        // GET: Raspisanies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspisanie = await _context.Raspisanies
                .Include(r => r.KartaKlienta)
                .Include(r => r.Trener)
                .Include(r => r.Vanna)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raspisanie == null)
            {
                return NotFound();
            }

            return View(raspisanie);
        }

        // GET: Raspisanies/Create
        public IActionResult Create()
        {
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "NomerKartKlienta");
            ViewData["TrenerID"] = new SelectList(_context.Treners, "Id", "FamiliR");
            ViewData["VannaID"] = new SelectList(_context.Vannas, "Id", "NomerVanna");
            return View();
        }

        // POST: Raspisanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KartaKlientaID,TrenerID,VannaID,DateNachala,DateEnd")] Raspisanie raspisanie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raspisanie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "Id", raspisanie.KartaKlientaID);
            ViewData["TrenerID"] = new SelectList(_context.Treners, "Id", "Id", raspisanie.TrenerID);
            ViewData["VannaID"] = new SelectList(_context.Vannas, "Id", "Id", raspisanie.VannaID);
            return View(raspisanie);
        }

        // GET: Raspisanies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspisanie = await _context.Raspisanies.FindAsync(id);
            if (raspisanie == null)
            {
                return NotFound();
            }
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "NomerKartKlienta", raspisanie.KartaKlientaID);
            ViewData["TrenerID"] = new SelectList(_context.Treners, "Id", "FamiliR", raspisanie.TrenerID);
            ViewData["VannaID"] = new SelectList(_context.Vannas, "Id", "NomerVanna", raspisanie.VannaID);
            return View(raspisanie);
        }

        // POST: Raspisanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KartaKlientaID,TrenerID,VannaID,DateNachala,DateEnd")] Raspisanie raspisanie)
        {
            if (id != raspisanie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raspisanie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaspisanieExists(raspisanie.Id))
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
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "Id", raspisanie.KartaKlientaID);
            ViewData["TrenerID"] = new SelectList(_context.Treners, "Id", "Id", raspisanie.TrenerID);
            ViewData["VannaID"] = new SelectList(_context.Vannas, "Id", "Id", raspisanie.VannaID);
            return View(raspisanie);
        }

        // GET: Raspisanies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raspisanie = await _context.Raspisanies
                .Include(r => r.KartaKlienta)
                .Include(r => r.Trener)
                .Include(r => r.Vanna)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raspisanie == null)
            {
                return NotFound();
            }

            return View(raspisanie);
        }

        // POST: Raspisanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raspisanie = await _context.Raspisanies.FindAsync(id);
            _context.Raspisanies.Remove(raspisanie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaspisanieExists(int id)
        {
            return _context.Raspisanies.Any(e => e.Id == id);
        }
    }
}
