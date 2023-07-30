using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasseinProekt.Models;
using BasseinProekta.Models;
using Microsoft.AspNetCore.Authorization;

namespace BasseinProekta.Controllers
{
    [Authorize ]
    public class KontaktsController : Controller
    {
        private readonly BasseinContext _context;

        public KontaktsController(BasseinContext context)
        {
            _context = context;
        }

        // GET: Kontakts
        public async Task<IActionResult> Index()
        {
            var basseinContext = _context.Kontakts.Include(k => k.Klient);
            return View(await basseinContext.ToListAsync());
        }

        // GET: Kontakts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakts
                .Include(k => k.Klient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontakt == null)
            {
                return NotFound();
            }

            return View(kontakt);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Kontakts/Create
        public IActionResult Create()
        {
            ViewData["KlientID"] = new SelectList(_context.Klients, "Id", "FamiliR");
            return View();
        }

        // POST: Kontakts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,KlientID,Email,Telefon")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontakt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlientID"] = new SelectList(_context.Klients, "Id", "Id", kontakt.KlientID);
            return View(kontakt);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Kontakts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakts.FindAsync(id);
            if (kontakt == null)
            {
                return NotFound();
            }
            ViewData["KlientID"] = new SelectList(_context.Klients, "Id", "Id", kontakt.KlientID);
            return View(kontakt);
        }

        // POST: Kontakts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KlientID,Email,Telefon")] Kontakt kontakt)
        {
            if (id != kontakt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kontakt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KontaktExists(kontakt.Id))
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
            ViewData["KlientID"] = new SelectList(_context.Klients, "Id", "Id", kontakt.KlientID);
            return View(kontakt);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Kontakts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakts
                .Include(k => k.Klient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontakt == null)
            {
                return NotFound();
            }

            return View(kontakt);
        }

        // POST: Kontakts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kontakt = await _context.Kontakts.FindAsync(id);
            _context.Kontakts.Remove(kontakt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KontaktExists(int id)
        {
            return _context.Kontakts.Any(e => e.Id == id);
        }
    }
}
