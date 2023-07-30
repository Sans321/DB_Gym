using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BasseinProekt.Models;
using BasseinProekta.Models;

namespace BasseinProekta.Controllers
{
    public class ZanRtisController : Controller
    {
        private readonly BasseinContext _context;

        public ZanRtisController(BasseinContext context)
        {
            _context = context;
        }

        // GET: ZanRtis
        public async Task<IActionResult> Index()
        {
            var basseinContext = _context.ZanRtis.Include(z => z.KartaKlienta).Include(z => z.TypeZanRti);
            return View(await basseinContext.ToListAsync());
        }

        // GET: ZanRtis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanRti = await _context.ZanRtis
                .Include(z => z.KartaKlienta)
                .Include(z => z.TypeZanRti)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zanRti == null)
            {
                return NotFound();
            }

            return View(zanRti);
        }

        // GET: ZanRtis/Create
        public IActionResult Create()
        {
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "NomerKartKlienta");
            ViewData["TypeZanRtiID"] = new SelectList(_context.TypeZanRtis, "Id", "Name");
            return View();
        }

        // POST: ZanRtis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KartaKlientaID,TypeZanRtiID,Cena")] ZanRti zanRti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zanRti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "NomerKartKlienta", zanRti.KartaKlientaID);
            ViewData["TypeZanRtiID"] = new SelectList(_context.TypeZanRtis, "Id", "Name", zanRti.TypeZanRtiID);
            return View(zanRti);
        }

        // GET: ZanRtis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanRti = await _context.ZanRtis.FindAsync(id);
            if (zanRti == null)
            {
                return NotFound();
            }
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "NomerKartKlienta", zanRti.KartaKlientaID);
            ViewData["TypeZanRtiID"] = new SelectList(_context.TypeZanRtis, "Id", "Name", zanRti.TypeZanRtiID);
            return View(zanRti);
        }

        // POST: ZanRtis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KartaKlientaID,TypeZanRtiID,Cena")] ZanRti zanRti)
        {
            if (id != zanRti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zanRti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZanRtiExists(zanRti.Id))
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
            ViewData["KartaKlientaID"] = new SelectList(_context.KartaKlientas, "Id", "NomerKartKlienta", zanRti.KartaKlientaID);
            ViewData["TypeZanRtiID"] = new SelectList(_context.TypeZanRtis, "Id", "Name", zanRti.TypeZanRtiID);
            return View(zanRti);
        }

        // GET: ZanRtis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanRti = await _context.ZanRtis
                .Include(z => z.KartaKlienta)
                .Include(z => z.TypeZanRti)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zanRti == null)
            {
                return NotFound();
            }

            return View(zanRti);
        }

        // POST: ZanRtis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zanRti = await _context.ZanRtis.FindAsync(id);
            _context.ZanRtis.Remove(zanRti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZanRtiExists(int id)
        {
            return _context.ZanRtis.Any(e => e.Id == id);
        }
    }
}
