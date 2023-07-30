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
    [Authorize(Roles = "admin , moderator, trener")]
    public class TypeTrenersController : Controller
    {
        private readonly BasseinContext _context;

        public TypeTrenersController(BasseinContext context)
        {
            _context = context;
        }

        // GET: TypeTreners
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeTreners.ToListAsync());
        }

        // GET: TypeTreners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeTrener = await _context.TypeTreners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeTrener == null)
            {
                return NotFound();
            }

            return View(typeTrener);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: TypeTreners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeTreners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Programma,Personal")] TypeTrener typeTrener)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeTrener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeTrener);
        }
        [Authorize(Roles = "admin , moderator,trener")]
        // GET: TypeTreners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeTrener = await _context.TypeTreners.FindAsync(id);
            if (typeTrener == null)
            {
                return NotFound();
            }
            return View(typeTrener);
        }

        // POST: TypeTreners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator,trener")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Programma,Personal")] TypeTrener typeTrener)
        {
            if (id != typeTrener.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeTrener);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeTrenerExists(typeTrener.Id))
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
            return View(typeTrener);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: TypeTreners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeTrener = await _context.TypeTreners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeTrener == null)
            {
                return NotFound();
            }

            return View(typeTrener);
        }

        // POST: TypeTreners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeTrener = await _context.TypeTreners.FindAsync(id);
            _context.TypeTreners.Remove(typeTrener);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeTrenerExists(int id)
        {
            return _context.TypeTreners.Any(e => e.Id == id);
        }
    }
}
