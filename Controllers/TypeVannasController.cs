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
    [Authorize(Roles = "admin , moderator")]
    public class TypeVannasController : Controller
    {
        private readonly BasseinContext _context;

        public TypeVannasController(BasseinContext context)
        {
            _context = context;
        }

        // GET: TypeVannas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeVannas.ToListAsync());
        }

        // GET: TypeVannas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeVanna = await _context.TypeVannas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeVanna == null)
            {
                return NotFound();
            }

            return View(typeVanna);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: TypeVannas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeVannas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Create([Bind("Id,Name,Material,Forma")] TypeVanna typeVanna)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeVanna);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeVanna);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: TypeVannas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeVanna = await _context.TypeVannas.FindAsync(id);
            if (typeVanna == null)
            {
                return NotFound();
            }
            return View(typeVanna);
        }

        // POST: TypeVannas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Material,Forma")] TypeVanna typeVanna)
        {
            if (id != typeVanna.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeVanna);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeVannaExists(typeVanna.Id))
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
            return View(typeVanna);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: TypeVannas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeVanna = await _context.TypeVannas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeVanna == null)
            {
                return NotFound();
            }

            return View(typeVanna);
        }

        // POST: TypeVannas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeVanna = await _context.TypeVannas.FindAsync(id);
            _context.TypeVannas.Remove(typeVanna);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeVannaExists(int id)
        {
            return _context.TypeVannas.Any(e => e.Id == id);
        }
    }
}
