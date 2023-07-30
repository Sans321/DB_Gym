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
    public class SpravkasController : Controller
    {
        private readonly BasseinContext _context;

        public SpravkasController(BasseinContext context)
        {
            _context = context;
        }

        // GET: Spravkas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spravkas.ToListAsync());
        }

        // GET: Spravkas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spravka = await _context.Spravkas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spravka == null)
            {
                return NotFound();
            }

            return View(spravka);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Spravkas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spravkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,DateNachala,DateEnd,GroupZdorovie,Dopusk")] Spravka spravka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spravka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spravka);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Spravkas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spravka = await _context.Spravkas.FindAsync(id);
            if (spravka == null)
            {
                return NotFound();
            }
            return View(spravka);
        }

        // POST: Spravkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateNachala,DateEnd,GroupZdorovie,Dopusk")] Spravka spravka)
        {
            if (id != spravka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spravka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpravkaExists(spravka.Id))
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
            return View(spravka);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Spravkas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spravka = await _context.Spravkas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spravka == null)
            {
                return NotFound();
            }

            return View(spravka);
        }

        // POST: Spravkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spravka = await _context.Spravkas.FindAsync(id);
            _context.Spravkas.Remove(spravka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpravkaExists(int id)
        {
            return _context.Spravkas.Any(e => e.Id == id);
        }
    }
}
