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
    public class ApartmentAvailabilitiesController : Controller
    {
        private readonly FoRentContext _context;

        public ApartmentAvailabilitiesController(FoRentContext context)
        {
            _context = context;
        }

        // GET: ApartmentAvailabilities
        public async Task<IActionResult> Index()
        {
            var foRentContext = _context.ApartmentAvailability.Include(a => a.Apartment).Include(a => a.Availability);
            return View(await foRentContext.ToListAsync());
        }

        // GET: ApartmentAvailabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentAvailability = await _context.ApartmentAvailability
                .Include(a => a.Apartment)
                .Include(a => a.Availability)
                .SingleOrDefaultAsync(m => m.AvailabilityId == id);
            if (apartmentAvailability == null)
            {
                return NotFound();
            }

            return View(apartmentAvailability);
        }

        // GET: ApartmentAvailabilities/Create
        public IActionResult Create()
        {
            ViewBag.anotherDate = "סמן תאריך כתפוס";
            return View();
        }

        // POST: ApartmentAvailabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DateTime date)
        {
            if (ModelState.IsValid)
            {
                ApartmentAvailability apartmentAvailability = new ApartmentAvailability();
                apartmentAvailability.Apartment = _context.Apartment.OrderByDescending(u => u.Id).FirstOrDefault();
                var result = from a in _context.ApartmentAvailability
                            where (a.Apartment.Equals(apartmentAvailability.Apartment))&&(a.Availability.NotAvailable.Equals(date))
                            select a;

                if (result.ToList().Count() > 0)
                    ViewBag.exist = "התאריך שבחרת כבר סומן כתפוס";
                else
                {
                    var temp = _context.Availability.Where(a => a.NotAvailable.Equals(date)).First();
  
                    apartmentAvailability.Availability = temp;
                    apartmentAvailability.AvailabilityId = temp.Id;
                    apartmentAvailability.ApartmentId = apartmentAvailability.Apartment.Id;
                    _context.Add(apartmentAvailability);
                    await _context.SaveChangesAsync();
                    
                }

                ViewBag.anotherDate = "סמן תאריך נוסף כתפוס";
            }
            //ViewData["ApartmentId"] = new SelectList(_context.Apartment, "Id", "Id", apartmentAvailability.ApartmentId);
            //ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Id", apartmentAvailability.AvailabilityId);
            return View();
        }

        // GET: ApartmentAvailabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentAvailability = await _context.ApartmentAvailability.SingleOrDefaultAsync(m => m.AvailabilityId == id);
            if (apartmentAvailability == null)
            {
                return NotFound();
            }
            ViewData["ApartmentId"] = new SelectList(_context.Apartment, "Id", "Id", apartmentAvailability.ApartmentId);
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Id", apartmentAvailability.AvailabilityId);
            return View(apartmentAvailability);
        }

        // POST: ApartmentAvailabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApartmentId,AvailabilityId")] ApartmentAvailability apartmentAvailability)
        {
            if (id != apartmentAvailability.AvailabilityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartmentAvailability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentAvailabilityExists(apartmentAvailability.AvailabilityId))
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
            ViewData["ApartmentId"] = new SelectList(_context.Apartment, "Id", "Id", apartmentAvailability.ApartmentId);
            ViewData["AvailabilityId"] = new SelectList(_context.Availability, "Id", "Id", apartmentAvailability.AvailabilityId);
            return View(apartmentAvailability);
        }

        // GET: ApartmentAvailabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentAvailability = await _context.ApartmentAvailability
                .Include(a => a.Apartment)
                .Include(a => a.Availability)
                .SingleOrDefaultAsync(m => m.AvailabilityId == id);
            if (apartmentAvailability == null)
            {
                return NotFound();
            }

            return View(apartmentAvailability);
        }

        // POST: ApartmentAvailabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartmentAvailability = await _context.ApartmentAvailability.SingleOrDefaultAsync(m => m.AvailabilityId == id);
            _context.ApartmentAvailability.Remove(apartmentAvailability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentAvailabilityExists(int id)
        {
            return _context.ApartmentAvailability.Any(e => e.AvailabilityId == id);
        }
    }
}
