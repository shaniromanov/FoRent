using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoRent.Models;
using Microsoft.AspNetCore.Authorization;

namespace FoRent.Controllers
{
  public class OrdersController : Controller
  {
    private readonly FoRentContext _context;

    public OrdersController(FoRentContext context)
    {
      _context = context;
    }

    // GET: Orders
    //[Authorize]
    public async Task<IActionResult> Index()
    {
      return View(await _context.Order.ToListAsync());
    }

    // GET: Orders/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var order = await _context.Order
          .SingleOrDefaultAsync(m => m.Id == id);
      if (order == null)
      {
        return NotFound();
      }

      return View(order);
    }

    // GET: Orders/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Orders/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ApartmentId,QuantityAdult,QuantityChild,CheckIn,CheckOut")] Order order)
    {
      if (ModelState.IsValid)
      {
        _context.Add(order);
        var days = GetStayDays(order.CheckIn, order.CheckOut);
        var naDays = days.Select(item => new ApartmentAvailability() { ApartmentId = order.ApartmentId, Availability = new Availability() { NotAvailable = item } });
        _context.ApartmentAvailability.AddRange(naDays);
        await _context.SaveChangesAsync();
        //return RedirectToAction(nameof(Index));
        return RedirectToAction("Create", "OrderPayments", routeValues: new { orderId= order.Id });
      }
      return View(order);
    }

    private IEnumerable<DateTime> GetStayDays(DateTime d1, DateTime d2)
    {
      TimeSpan ts = d2 - d1;
      IEnumerable<int> hoursBetween = Enumerable.Range(0, (int)ts.TotalHours)
        .Select(i => d1.AddHours(i).Hour);
      int dayOffSet = 0;
      return hoursBetween.Select(hr => new DateTime(d1.AddDays(hr == 0 ? ++dayOffSet : dayOffSet).Year, d1.AddDays(dayOffSet).Month, d1.AddDays(dayOffSet).Day, hr, d1.AddDays(dayOffSet).Minute, d1.AddDays(dayOffSet).Second));
    }

    // GET: Orders/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var order = await _context.Order.SingleOrDefaultAsync(m => m.Id == id);
      if (order == null)
      {
        return NotFound();
      }
      return View(order);
    }

    // POST: Orders/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,ApartmentId,QuantityAdult,QuantityChild,CheckIn,CheckOut")] Order order)
    {
      if (id != order.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(order);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!OrderExists(order.Id))
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
      return View(order);
    }

    // GET: Orders/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var order = await _context.Order
          .SingleOrDefaultAsync(m => m.Id == id);
      if (order == null)
      {
        return NotFound();
      }

      return View(order);
    }

    // POST: Orders/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var order = await _context.Order.SingleOrDefaultAsync(m => m.Id == id);
      _context.Order.Remove(order);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool OrderExists(int id)
    {
      return _context.Order.Any(e => e.Id == id);
    }


    public IActionResult Success()
    {
      return View();
    }
  }
}
