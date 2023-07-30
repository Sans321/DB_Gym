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
    [Authorize]
    public class KlientsController : Controller
    {
        private readonly BasseinContext _context;

        public KlientsController(BasseinContext context)
        {
            _context = context;
        }

        // GET: Klients
        public async Task<IActionResult> Index()
        {
            var basseinContext = _context.Klients.Include(k => k.Spravka);
            return View(await basseinContext.ToListAsync());
        }

        // GET: Klients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klients
                .Include(k => k.Spravka)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Klients/Create
        public IActionResult Create()
        {
            ViewData["SpravkaID"] = new SelectList(_context.Spravkas, "Id", "Id");
            return View();
        }

        // POST: Klients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,SpravkaID,FamiliR,ImR,Otchestvo,SeriaPasport,NomerPasporta")] Klient klient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(klient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpravkaID"] = new SelectList(_context.Spravkas, "Id", "Id", klient.SpravkaID);
            return View(klient);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Klients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klients.FindAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
            ViewData["SpravkaID"] = new SelectList(_context.Spravkas, "Id", "Id", klient.SpravkaID);
            return View(klient);
        }

        // POST: Klients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SpravkaID,FamiliR,ImR,Otchestvo,SeriaPasport,NomerPasporta")] Klient klient)
        {
            if (id != klient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(klient.Id))
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
            ViewData["SpravkaID"] = new SelectList(_context.Spravkas, "Id", "Id", klient.SpravkaID);
            return View(klient);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Klients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klient = await _context.Klients
                .Include(k => k.Spravka)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (klient == null)
            {
                return NotFound();
            }

            return View(klient);
        }

        // POST: Klients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klient = await _context.Klients.FindAsync(id);
            _context.Klients.Remove(klient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlientExists(int id)
        {
            return _context.Klients.Any(e => e.Id == id);
        }
    }
}
