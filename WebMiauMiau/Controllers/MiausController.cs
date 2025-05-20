using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMiauMiau.Data;
using WebMiauMiau.Models;

namespace WebMiauMiau.Controllers
{
    public class MiausController : Controller
    {
        private readonly WebMiauMiauContext _context;

        public MiausController(WebMiauMiauContext context)
        {
            _context = context;
        }

        // GET: Miaus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Miau.ToListAsync());
        }

        // GET: Miaus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miau = await _context.Miau
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miau == null)
            {
                return NotFound();
            }

            return View(miau);
        }

        // GET: Miaus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Miaus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Raca,idade,cor,status,UF")] Miau miau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(miau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(miau);
        }

        // GET: Miaus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miau = await _context.Miau.FindAsync(id);
            if (miau == null)
            {
                return NotFound();
            }
            return View(miau);
        }

        // POST: Miaus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Raca,idade,cor,status,UF")] Miau miau)
        {
            if (id != miau.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(miau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiauExists(miau.Id))
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
            return View(miau);
        }

        // GET: Miaus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var miau = await _context.Miau
                .FirstOrDefaultAsync(m => m.Id == id);
            if (miau == null)
            {
                return NotFound();
            }

            return View(miau);
        }

        // POST: Miaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var miau = await _context.Miau.FindAsync(id);
            if (miau != null)
            {
                _context.Miau.Remove(miau);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiauExists(int id)
        {
            return _context.Miau.Any(e => e.Id == id);
        }
    }
}
