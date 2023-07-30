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
    public class KartaKlientasController : Controller
    {
        private readonly BasseinContext _context;

        public KartaKlientasController(BasseinContext context)
        {
            _context = context;
        }

        // GET: KartaKlientas
        public async Task<IActionResult> Index()
        {
            var basseinContext = _context.KartaKlientas.Include(k => k.Karta).Include(k => k.Klient);
            return View(await basseinContext.ToListAsync());
        }

        // GET: KartaKlientas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartaKlienta = await _context.KartaKlientas
                .Include(k => k.Karta)
                .Include(k => k.Klient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kartaKlienta == null)
            {
                return NotFound();
            }

            return View(kartaKlienta);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: KartaKlientas/Create
        public IActionResult Create()
        {
            ViewData["KartaID"] = new SelectList(_context.Kartas, "Id", "Id");
            ViewData["KlientID"] = new SelectList(_context.Klients, "Id", "FamiliR");
            ViewData["SpravkaID"] = new SelectList(_context.Spravkas, "Id", "Dopusk");
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Name");
            return View();
        }

        // POST: KartaKlientas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,KartaID,KlientID,SpravkaID,GroupID,DateNachala,DateEnd,NomerKartKlienta")] KartaKlienta kartaKlienta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kartaKlienta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KartaID"] = new SelectList(_context.Kartas, "Id", "Id", kartaKlienta.KartaID);
            ViewData["KlientID"] = new SelectList(_context.Klients, "Id", "Id", kartaKlienta.KlientID);
            return View(kartaKlienta);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: KartaKlientas/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var kartaKlienta = await _context.KartaKlientas.FindAsync(id);
        //    if (kartaKlienta == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["KartaID"] = new SelectList(_context.Kartas, "Id", "Id", kartaKlienta.KartaID);
        //    ViewData["KlientID"] = new SelectList(_context.Klients, "Id", "Id", kartaKlienta.KlientID); 
        //}

        // POST: KartaKlientas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KartaID,KlientID,SpravkaID,GroupID,DateNachala,DateEnd,NomerKartKlienta")] KartaKlienta kartaKlienta)
        {
            if (id != kartaKlienta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kartaKlienta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KartaKlientaExists(kartaKlienta.Id))
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
            ViewData["KartaID"] = new SelectList(_context.Kartas, "Id", "Id", kartaKlienta.KartaID);
            ViewData["KlientID"] = new SelectList(_context.Klients, "Id", "Id", kartaKlienta.KlientID);
            return View(kartaKlienta);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: KartaKlientas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartaKlienta = await _context.KartaKlientas
                .Include(k => k.Karta)
                .Include(k => k.Klient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kartaKlienta == null)
            {
                return NotFound();
            }

            return View(kartaKlienta);
        }

        // POST: KartaKlientas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kartaKlienta = await _context.KartaKlientas.FindAsync(id);
            _context.KartaKlientas.Remove(kartaKlienta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KartaKlientaExists(int id)
        {
            return _context.KartaKlientas.Any(e => e.Id == id);
        }
    }
}
