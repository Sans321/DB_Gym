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
    public class TrenersController : Controller
    {
        private readonly BasseinContext _context;

        public TrenersController(BasseinContext context)
        {
            _context = context;
        }

        // GET: Treners
        public async Task<IActionResult> Index()
        {
            var basseinContext = _context.Treners.Include(t => t.Group).Include(t => t.TypeTrener);
            return View(await basseinContext.ToListAsync());
        }

        // GET: Treners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trener = await _context.Treners
                .Include(t => t.Group)
                .Include(t => t.TypeTrener)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trener == null)
            {
                return NotFound();
            }

            return View(trener);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Treners/Create
        public IActionResult Create()
        {
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "TypeGroupID");
            ViewData["TypeTrenerID"] = new SelectList(_context.TypeTreners, "Id", "Programma");
            return View();
        }

        // POST: Treners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,FamiliR,ImR,Otchestvo,GroupID,TypeTrenerID")] Trener trener)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Name", trener.GroupID);
            ViewData["TypeTrenerID"] = new SelectList(_context.TypeTreners, "Id", "Programma", trener.TypeTrenerID);
            return View(trener);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Treners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trener = await _context.Treners.FindAsync(id);
            if (trener == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Name", trener.GroupID);
            ViewData["TypeTrenerID"] = new SelectList(_context.TypeTreners, "Id", "Programma", trener.TypeTrenerID);
            return View(trener);
        }

        // POST: Treners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FamiliR,ImR,Otchestvo,GroupID,TypeTrenerID")] Trener trener)
        {
            if (id != trener.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trener);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrenerExists(trener.Id))
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
            ViewData["GroupID"] = new SelectList(_context.Groups, "Id", "Id", trener.GroupID);
            ViewData["TypeTrenerID"] = new SelectList(_context.TypeTreners, "Id", "Id", trener.TypeTrenerID);
            return View(trener);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Treners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trener = await _context.Treners
                .Include(t => t.Group)
                .Include(t => t.TypeTrener)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trener == null)
            {
                return NotFound();
            }

            return View(trener);
        }

        // POST: Treners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trener = await _context.Treners.FindAsync(id);
            _context.Treners.Remove(trener);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrenerExists(int id)
        {
            return _context.Treners.Any(e => e.Id == id);
        }
    }
}
