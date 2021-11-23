using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1.Models;

namespace UCP1.Controllers
{
    public class AplikasisController : Controller
    {
        private readonly UCPContext _context;

        public AplikasisController(UCPContext context)
        {
            _context = context;
        }

        // GET: Aplikasis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aplikasi.ToListAsync());
        }

        // GET: Aplikasis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplikasi = await _context.Aplikasi
                .FirstOrDefaultAsync(m => m.IdAplikasi == id);
            if (aplikasi == null)
            {
                return NotFound();
            }

            return View(aplikasi);
        }

        // GET: Aplikasis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aplikasis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAplikasi,AdventureGenre,ActionGenre,FantasyGenre")] Aplikasi aplikasi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aplikasi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aplikasi);
        }

        // GET: Aplikasis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplikasi = await _context.Aplikasi.FindAsync(id);
            if (aplikasi == null)
            {
                return NotFound();
            }
            return View(aplikasi);
        }

        // POST: Aplikasis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAplikasi,AdventureGenre,ActionGenre,FantasyGenre")] Aplikasi aplikasi)
        {
            if (id != aplikasi.IdAplikasi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aplikasi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AplikasiExists(aplikasi.IdAplikasi))
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
            return View(aplikasi);
        }

        // GET: Aplikasis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aplikasi = await _context.Aplikasi
                .FirstOrDefaultAsync(m => m.IdAplikasi == id);
            if (aplikasi == null)
            {
                return NotFound();
            }

            return View(aplikasi);
        }

        // POST: Aplikasis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aplikasi = await _context.Aplikasi.FindAsync(id);
            _context.Aplikasi.Remove(aplikasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AplikasiExists(int id)
        {
            return _context.Aplikasi.Any(e => e.IdAplikasi == id);
        }
    }
}
