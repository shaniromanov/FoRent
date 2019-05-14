using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoRent.Models;

namespace FoRent.Controllers
{
    public class HirersController : Controller
    {
        private readonly FoRentContext _context;

        public HirersController(FoRentContext context)
        {
            _context = context;
        }

        // GET: Hirers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hirer.ToListAsync());
        }

        // GET: Hirers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hirer = await _context.Hirer
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hirer == null)
            {
                return NotFound();
            }

            return View(hirer);
        }

        // GET: Hirers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hirers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Phone,Mail,Username,Password")] Hirer hirer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hirer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hirer);
        }

        // GET: Hirers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hirer = await _context.Hirer.SingleOrDefaultAsync(m => m.Id == id);
            if (hirer == null)
            {
                return NotFound();
            }
            return View(hirer);
        }

        // POST: Hirers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Phone,Mail,Username,Password")] Hirer hirer)
        {
            if (id != hirer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hirer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HirerExists(hirer.Id))
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
            return View(hirer);
        }

        // GET: Hirers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hirer = await _context.Hirer
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hirer == null)
            {
                return NotFound();
            }

            return View(hirer);
        }

        // POST: Hirers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hirer = await _context.Hirer.SingleOrDefaultAsync(m => m.Id == id);
            _context.Hirer.Remove(hirer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HirerExists(int id)
        {
            return _context.Hirer.Any(e => e.Id == id);
        }
    }
}
