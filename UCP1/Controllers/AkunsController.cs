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
    public class AkunsController : Controller
    {
        private readonly UCPContext _context;

        public AkunsController(UCPContext context)
        {
            _context = context;
        }

        // GET: Akuns
        public async Task<IActionResult> Index()
        {
            return View(await _context.Akun.ToListAsync());
        }

        // GET: Akuns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var akun = await _context.Akun
                .FirstOrDefaultAsync(m => m.IdAkun == id);
            if (akun == null)
            {
                return NotFound();
            }

            return View(akun);
        }

        // GET: Akuns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Akuns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAkun,Email,Password")] Akun akun)
        {
            if (ModelState.IsValid)
            {
                _context.Add(akun);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(akun);
        }

        // GET: Akuns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var akun = await _context.Akun.FindAsync(id);
            if (akun == null)
            {
                return NotFound();
            }
            return View(akun);
        }

        // POST: Akuns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAkun,Email,Password")] Akun akun)
        {
            if (id != akun.IdAkun)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(akun);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AkunExists(akun.IdAkun))
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
            return View(akun);
        }

        // GET: Akuns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var akun = await _context.Akun
                .FirstOrDefaultAsync(m => m.IdAkun == id);
            if (akun == null)
            {
                return NotFound();
            }

            return View(akun);
        }

        // POST: Akuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var akun = await _context.Akun.FindAsync(id);
            _context.Akun.Remove(akun);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AkunExists(int id)
        {
            return _context.Akun.Any(e => e.IdAkun == id);
        }
    }
}
