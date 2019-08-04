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
    public class ApartmentsController : Controller
    {
        private readonly FoRentContext _context;

        public ApartmentsController(FoRentContext context)
        {
            _context = context;
        }

        // GET: Apartments
        public async Task<IActionResult> Index(string city, DateTime checkIn, DateTime checkOut, int adult, int child)
        {
            ViewBag.NumOfAdult = adult;
            ViewBag.NumOfChild = child;
            var databaseContext = _context.Apartment.Include(a => a.Amenities).Include(l => l.Location).Include(r => r.Renter).Include(p => p.Policy);

            return View(await databaseContext.Where(p => p.Location.City.Contains(city) && ((p.Amenities.NumOfPersons) >= (adult + child))).ToListAsync());
        }


        public IActionResult Home()
        {
            return View();
        }




        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment.Include(a => a.Amenities).Include(p => p.Policy).Include(l => l.Location)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {

            return View();

        }

        // POST: Apartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PriceAdult,PriceChild")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                apartment.Renter = _context.Renter.OrderByDescending(u => u.Id).FirstOrDefault();
                apartment.Location = _context.Location.OrderByDescending(u => u.Id).FirstOrDefault();
                apartment.Amenities = _context.ApartmentAmenities.OrderByDescending(u => u.Id).FirstOrDefault();
                apartment.Policy = _context.Policy.OrderByDescending(u => u.Id).FirstOrDefault();
                apartment.Image = _context.Image.OrderByDescending(u => u.Id).FirstOrDefault();


                _context.Add(apartment);
                await _context.SaveChangesAsync();
              
                return RedirectToAction("Success","Apartments");
            }
            ViewBag.Success = false;
            return View(apartment);

        }
  
            
        
        public async Task<IActionResult> Search()
        {
            return View(await _context.Apartment.Where(p => p.Location.City.Contains((String)TempData["City"])&&((p.Amenities.NumOfPersons)>=((int)TempData["Adult"]+ (int)TempData["Child"]))).ToListAsync());
        }


        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment.SingleOrDefaultAsync(m => m.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }
            return View(apartment);
        }

        // POST: Apartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PriceAdult,PriceChild,Amenties")] Apartment apartment)
        {
            if (id != apartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentExists(apartment.Id))
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
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment
                .SingleOrDefaultAsync(m => m.Id == id);
            if (apartment == null)
            {
                return NotFound();
            }

            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartment.SingleOrDefaultAsync(m => m.Id == id);
            _context.Apartment.Remove(apartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartment.Any(e => e.Id == id);
        }
    }
}
