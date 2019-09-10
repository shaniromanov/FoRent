using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoRent.Models;
using Microsoft.AspNetCore.Http;

namespace FoRent.Controllers
{
    public class OrderPaymentsController : Controller
    {
        private readonly FoRentContext _context;

        public OrderPaymentsController(FoRentContext context)
        {
            _context = context;
        }

        // GET: OrderPayments
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderPayments.ToListAsync());
        }

        // GET: OrderPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPayment = await _context.OrderPayments
                .SingleOrDefaultAsync(m => m.OrderPaymentId == id);
            if (orderPayment == null)
            {
                return NotFound();
            }

            return View(orderPayment);
        }

        // GET: OrderPayments/Create
        public IActionResult Create(int orderId)
        {
            HttpContext.Session.SetInt32("OrderId",orderId);
            return View();
        }

        // POST: OrderPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderPaymentId,CC_Number,CC_Exp,CC_CVV")] OrderPayment orderPayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderPayment);
                await _context.SaveChangesAsync();
                int orderId = HttpContext.Session.GetInt32("OrderId").Value;
                HttpContext.Session.Remove("OrderId");
                var dbOrder = _context.Order.Find(orderId);
                dbOrder.PaymentId = orderPayment.OrderPaymentId;
                await _context.SaveChangesAsync();
                return RedirectToAction("Success","Orders");
            }
            return View(orderPayment);
        }

        // GET: OrderPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPayment = await _context.OrderPayments.SingleOrDefaultAsync(m => m.OrderPaymentId == id);
            if (orderPayment == null)
            {
                return NotFound();
            }
            return View(orderPayment);
        }

        // POST: OrderPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderPaymentId,CC_Number,CC_Exp,CC_CVV")] OrderPayment orderPayment)
        {
            if (id != orderPayment.OrderPaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderPayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderPaymentExists(orderPayment.OrderPaymentId))
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
            return View(orderPayment);
        }

        // GET: OrderPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderPayment = await _context.OrderPayments
                .SingleOrDefaultAsync(m => m.OrderPaymentId == id);
            if (orderPayment == null)
            {
                return NotFound();
            }

            return View(orderPayment);
        }

        // POST: OrderPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderPayment = await _context.OrderPayments.SingleOrDefaultAsync(m => m.OrderPaymentId == id);
            _context.OrderPayments.Remove(orderPayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderPaymentExists(int id)
        {
            return _context.OrderPayments.Any(e => e.OrderPaymentId == id);
        }
    }
}
