using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Semestrovka.Data;
using Semestrovka.Models.DBModels;

namespace Semestrovka.Controllers
{
    public class CartController : Controller
    {
        private readonly d6h4jeg5tcb9d8Context _context;

        public CartController(d6h4jeg5tcb9d8Context context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Cart()
        {
            var d6H4Jeg5Tcb9d8Context = _context.Orders.Include(o => o.DeliveryNavigation)
                .Include(o => o.OwnerNavigation).Include(o => o.StatusNavigation);
            return View(await d6H4Jeg5Tcb9d8Context.ToListAsync());
        }

        public IActionResult Checkout()
        {
            return View();
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var orders = await _context.Orders
                .Include(o => o.DeliveryNavigation)
                .Include(o => o.OwnerNavigation)
                .Include(o => o.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (orders == null) return NotFound();

            return View(orders);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            ViewData["Delivery"] = new SelectList(_context.Deliveries, "Id", "Id");
            ViewData["Owner"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["Status"] = new SelectList(_context.Statuses, "Id", "Id");
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Owner,Status,Datecreated,Delivery,Address,PayType,PhoneNumber,Email")]
            Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Cart));
            }

            ViewData["Delivery"] = new SelectList(_context.Deliveries, "Id", "Id", orders.Delivery);
            ViewData["Owner"] = new SelectList(_context.Users, "Id", "Id", orders.Owner);
            ViewData["Status"] = new SelectList(_context.Statuses, "Id", "Id", orders.Status);
            return View(orders);
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var orders = await _context.Orders.FindAsync(id);

            if (orders == null) return NotFound();

            ViewData["Delivery"] = new SelectList(_context.Deliveries, "Id", "Id", orders.Delivery);
            ViewData["Owner"] = new SelectList(_context.Users, "Id", "Id", orders.Owner);
            ViewData["Status"] = new SelectList(_context.Statuses, "Id", "Id", orders.Status);
            return View(orders);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Owner,Status,Datecreated,Delivery,Address,PayType,PhoneNumber,Email")]
            Orders orders)
        {
            if (id != orders.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id)) return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Cart));
            }

            ViewData["Delivery"] = new SelectList(_context.Deliveries, "Id", "Id", orders.Delivery);
            ViewData["Owner"] = new SelectList(_context.Users, "Id", "Id", orders.Owner);
            ViewData["Status"] = new SelectList(_context.Statuses, "Id", "Id", orders.Status);
            return View(orders);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var orders = await _context.Orders
                .Include(o => o.DeliveryNavigation)
                .Include(o => o.OwnerNavigation)
                .Include(o => o.StatusNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (orders == null) return NotFound();
            await DeleteConfirmed(Convert.ToInt32(id));
            return RedirectToAction("Cart");
        }

        // POST: Cart/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction("Cart");
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}