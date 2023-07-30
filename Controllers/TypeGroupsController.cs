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
    public class TypeGroupsController : Controller
    {
        private readonly BasseinContext _context;

        public TypeGroupsController(BasseinContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: TypeGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeGroups.ToListAsync());
        }

        // GET: TypeGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeGroup = await _context.TypeGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeGroup == null)
            {
                return NotFound();
            }

            return View(typeGroup);
        }
        [Authorize(Roles = "admin , moderator, trener")]
        // GET: TypeGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator, trener")]
        public async Task<IActionResult> Create([Bind("Id,NameGroup,Nomer")] TypeGroup typeGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeGroup);
        }
        [Authorize(Roles = "admin , moderator, trener")]
        // GET: TypeGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeGroup = await _context.TypeGroups.FindAsync(id);
            if (typeGroup == null)
            {
                return NotFound();
            }
            return View(typeGroup);
        }

        // POST: TypeGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator trener")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameGroup,Nomer")] TypeGroup typeGroup)
        {
            if (id != typeGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeGroupExists(typeGroup.Id))
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
            return View(typeGroup);
        }
        [Authorize(Roles = "admin , moderator")]
        // GET: TypeGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeGroup = await _context.TypeGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeGroup == null)
            {
                return NotFound();
            }

            return View(typeGroup);
        }

        // POST: TypeGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeGroup = await _context.TypeGroups.FindAsync(id);
            _context.TypeGroups.Remove(typeGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeGroupExists(int id)
        {
            return _context.TypeGroups.Any(e => e.Id == id);
        }
    }
}
