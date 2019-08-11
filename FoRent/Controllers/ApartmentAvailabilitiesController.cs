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
            ViewBag.anotherDate = "סמן תאריך נוסף כתפוס";
            if (ModelState.IsValid)
            {
                ApartmentAvailability apartmentAvailability = new ApartmentAvailability();
                apartmentAvailability.Apartment = _context.Apartment.Where(u => u.Id==(int)TempData["Availability"]).FirstOrDefault();
                var result = from a in _context.ApartmentAvailability
                            where (a.Apartment.Equals(apartmentAvailability.Apartment))&&(a.Availability.NotAvailable.Equals(date))
                            select a;

                if (result.ToList().Count() > 0)
                    ViewBag.errorTime = "*התאריך שבחרת כבר סומן כתפוס";
                else if (date.CompareTo(DateTime.Now.AddMonths(3))>0) {
                    ViewBag.errorTime = "*יש להזין תאריכים בתווך של 3 חודשים מהיום";
                }
                else
                {
                   
  
                    apartmentAvailability.Availability = _context.Availability.Where(a => a.NotAvailable.Equals(date)).FirstOrDefault(); ;
                    apartmentAvailability.AvailabilityId = apartmentAvailability.Availability.Id;
                    apartmentAvailability.ApartmentId = (int)TempData["Availability"];
                    _context.Add(apartmentAvailability);
                    await _context.SaveChangesAsync();
                    
                }

                TempData["Availability"] = TempData["Availability"];
            }
           
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
