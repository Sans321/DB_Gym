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
    public class VannasController : Controller
    {
        private readonly BasseinContext _context;

        public VannasController(BasseinContext context)
        {
            _context = context;
        }

        // GET: Vannas
        public async Task<IActionResult> Index()
        {
            var basseinContext = _context.Vannas.Include(v => v.TypeVanna);
            return View(await basseinContext.ToListAsync());
        }

        // GET: Vannas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vanna = await _context.Vannas
                .Include(v => v.TypeVanna)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vanna == null)
            {
                return NotFound();
            }

            return View(vanna);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Vannas/Create
        public IActionResult Create()
        {
            ViewData["TypeVannaID"] = new SelectList(_context.TypeVannas, "Id", "Name");
            return View();
        }

        // POST: Vannas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,TypeVannaID,NomerVanna,Shirina,Glubina,Dlina")] Vanna vanna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vanna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeVannaID"] = new SelectList(_context.TypeVannas, "Id", "Name", vanna.TypeVannaID);
            return View(vanna);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Vannas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vanna = await _context.Vannas.FindAsync(id);
            if (vanna == null)
            {
                return NotFound();
            }
            ViewData["TypeVannaID"] = new SelectList(_context.TypeVannas, "Id", "Name", vanna.TypeVannaID);
            return View(vanna);
        }

        // POST: Vannas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeVannaID,NomerVanna,Shirina,Glubina,Dlina")] Vanna vanna)
        {
            if (id != vanna.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vanna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VannaExists(vanna.Id))
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
            ViewData["TypeVannaID"] = new SelectList(_context.TypeVannas, "Id", "Name", vanna.TypeVannaID);
            return View(vanna);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: Vannas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vanna = await _context.Vannas
                .Include(v => v.TypeVanna)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vanna == null)
            {
                return NotFound();
            }

            return View(vanna);
        }

        // POST: Vannas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vanna = await _context.Vannas.FindAsync(id);
            _context.Vannas.Remove(vanna);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VannaExists(int id)
        {
            return _context.Vannas.Any(e => e.Id == id);
        }
    }
}
