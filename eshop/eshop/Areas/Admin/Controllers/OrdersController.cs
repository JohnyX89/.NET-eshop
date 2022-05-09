using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eshop.Models;
using eshop.Models.Database;
using Microsoft.AspNetCore.Authorization;
using eshop.Models.Identity;
using Microsoft.Extensions.Logging;
using eshop.Controllers;

namespace eshop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]         // just admin and manager have authorization to Orders
    public class OrdersController : Controller
    {
        private readonly EshopDBContext _context;
        readonly ILogger<HomeController> logger;


        public OrdersController(EshopDBContext context, ILogger<HomeController> logger)
        {
            _context = context;
            this.logger = logger;
        }

        // GET: Admin/Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Admin/Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.ID == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Admin/Orders/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Admin/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderNumber,TotalPrice,UserId,ID,DateTimeCreated")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            return View(order);
        }

        // GET: Admin/Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", order.UserId);
            return View(order);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            Order orderItem = _context.Orders.Where(orderId => orderId.ID == order.ID).FirstOrDefault();

            if (orderItem != null)
            {
                orderItem.OrderNumber = order.OrderNumber;
                orderItem.TotalPrice = order.TotalPrice;
                bool confirmationChanged = false;

                if (orderItem.Confirmed != order.Confirmed)
                {
                    confirmationChanged = true;
                }

                orderItem.Confirmed = order.Confirmed;

                await _context.SaveChangesAsync();

                if (confirmationChanged)
                {
                    if (orderItem.Confirmed == true)
                    {
                        logger.LogInformation("Order " + order.ID + "was changed to 'Confirmed' ");
                    }
                    else
                    {
                        logger.LogInformation("Order " + order.ID + "was changed to 'Not Confirmed' ");
                    }
                }

                return RedirectToAction(nameof(Index));    // back to Order review
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Admin/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Admin/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            logger.LogInformation("Order " + order.ID + "was deleted");

            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }

    }
}
