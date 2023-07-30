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
    public class KartasController : Controller
    {
        private readonly BasseinContext _context;

        public KartasController(BasseinContext context)
        {
            _context = context;
        }

        // GET: Kartas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kartas.ToListAsync());
        }

        // GET: Kartas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karta = await _context.Kartas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karta == null)
            {
                return NotFound();
            }

            return View(karta);
        }

        // GET: Kartas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kartas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateNachala,DateEnd")] Karta karta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(karta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(karta);
        }

        // GET: Kartas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karta = await _context.Kartas.FindAsync(id);
            if (karta == null)
            {
                return NotFound();
            }
            return View(karta);
        }

        // POST: Kartas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateNachala,DateEnd")] Karta karta)
        {
            if (id != karta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(karta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KartaExists(karta.Id))
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
            return View(karta);
        }

        // GET: Kartas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var karta = await _context.Kartas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (karta == null)
            {
                return NotFound();
            }

            return View(karta);
        }

        // POST: Kartas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var karta = await _context.Kartas.FindAsync(id);
            _context.Kartas.Remove(karta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KartaExists(int id)
        {
            return _context.Kartas.Any(e => e.Id == id);
        }
    }
}
