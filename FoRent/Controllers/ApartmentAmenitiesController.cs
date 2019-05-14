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
    public class ApartmentAmenitiesController : Controller
    {
        private readonly FoRentContext _context;

        public ApartmentAmenitiesController(FoRentContext context)
        {
            _context = context;
        }

        // GET: ApartmentAmenities
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApartmentAmenities.ToListAsync());
        }

        // GET: ApartmentAmenities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentAmenities = await _context.ApartmentAmenities
                .SingleOrDefaultAsync(m => m.Id == id);
            if (apartmentAmenities == null)
            {
                return NotFound();
            }

            return View(apartmentAmenities);
        }

        // GET: ApartmentAmenities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApartmentAmenities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumOfRooms,NumOfPersons,Description,Parking,Wifi,Accessibility,AirConditioning,Balcony,Comment")] ApartmentAmenities apartmentAmenities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartmentAmenities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apartmentAmenities);
        }

        // GET: ApartmentAmenities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentAmenities = await _context.ApartmentAmenities.SingleOrDefaultAsync(m => m.Id == id);
            if (apartmentAmenities == null)
            {
                return NotFound();
            }
            return View(apartmentAmenities);
        }

        // POST: ApartmentAmenities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumOfRooms,NumOfPersons,Description,Parking,Wifi,Accessibility,AirConditioning,Balcony,Comment")] ApartmentAmenities apartmentAmenities)
        {
            if (id != apartmentAmenities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartmentAmenities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentAmenitiesExists(apartmentAmenities.Id))
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
            return View(apartmentAmenities);
        }

        // GET: ApartmentAmenities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartmentAmenities = await _context.ApartmentAmenities
                .SingleOrDefaultAsync(m => m.Id == id);
            if (apartmentAmenities == null)
            {
                return NotFound();
            }

            return View(apartmentAmenities);
        }

        // POST: ApartmentAmenities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartmentAmenities = await _context.ApartmentAmenities.SingleOrDefaultAsync(m => m.Id == id);
            _context.ApartmentAmenities.Remove(apartmentAmenities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentAmenitiesExists(int id)
        {
            return _context.ApartmentAmenities.Any(e => e.Id == id);
        }
    }
}
