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
    public class TypeZanRtisController : Controller
    {
        private readonly BasseinContext _context;

        public TypeZanRtisController(BasseinContext context)
        {
            _context = context;
        }

        // GET: TypeZanRtis
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeZanRtis.ToListAsync());
        }

        // GET: TypeZanRtis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeZanRti = await _context.TypeZanRtis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeZanRti == null)
            {
                return NotFound();
            }

            return View(typeZanRti);
        }
        [Authorize(Roles = "admin , moderator, trener")]
        // GET: TypeZanRtis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeZanRtis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator, trener")]
        public async Task<IActionResult> Create([Bind("Id,Name,Programma")] TypeZanRti typeZanRti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeZanRti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeZanRti);
        }
        [Authorize(Roles = "admin , moderator, trener")]
        // GET: TypeZanRtis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeZanRti = await _context.TypeZanRtis.FindAsync(id);
            if (typeZanRti == null)
            {
                return NotFound();
            }
            return View(typeZanRti);
        }

        // POST: TypeZanRtis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator, trener")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Programma")] TypeZanRti typeZanRti)
        {
            if (id != typeZanRti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeZanRti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeZanRtiExists(typeZanRti.Id))
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
            return View(typeZanRti);
        }
        [Authorize(Roles = "admin , moderator, trener")]
        // GET: TypeZanRtis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeZanRti = await _context.TypeZanRtis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeZanRti == null)
            {
                return NotFound();
            }

            return View(typeZanRti);
        }

        // POST: TypeZanRtis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator, trener")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeZanRti = await _context.TypeZanRtis.FindAsync(id);
            _context.TypeZanRtis.Remove(typeZanRti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeZanRtiExists(int id)
        {
            return _context.TypeZanRtis.Any(e => e.Id == id);
        }
    }
}
