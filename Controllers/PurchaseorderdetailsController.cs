using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMP.Models;

namespace CMP.Controllers
{
    public class PurchaseorderdetailsController : Controller
    {
        private readonly CmpContext _context;

        public PurchaseorderdetailsController(CmpContext context)
        {
            _context = context;
        }

        // GET: Purchaseorderdetails
        public async Task<IActionResult> Index()
        {
            var cmpContext = _context.Purchaseorderdetails.Include(p => p.Order).Include(p => p.Product);
            return View(await cmpContext.ToListAsync());
        }

        // GET: Purchaseorderdetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseorderdetail = await _context.Purchaseorderdetails
                .Include(p => p.Order)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.OrderdetailsId == id);
            if (purchaseorderdetail == null)
            {
                return NotFound();
            }

            return View(purchaseorderdetail);
        }

        // GET: Purchaseorderdetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Purchaseorders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            return View();
        }

        // POST: Purchaseorderdetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderdetailsId,OrderId,ProductId")] Purchaseorderdetail purchaseorderdetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseorderdetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Purchaseorders, "OrderId", "OrderId", purchaseorderdetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", purchaseorderdetail.ProductId);
            return View(purchaseorderdetail);
        }

        // GET: Purchaseorderdetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseorderdetail = await _context.Purchaseorderdetails.FindAsync(id);
            if (purchaseorderdetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Purchaseorders, "OrderId", "OrderId", purchaseorderdetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", purchaseorderdetail.ProductId);
            return View(purchaseorderdetail);
        }

        // POST: Purchaseorderdetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderdetailsId,OrderId,ProductId")] Purchaseorderdetail purchaseorderdetail)
        {
            if (id != purchaseorderdetail.OrderdetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseorderdetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseorderdetailExists(purchaseorderdetail.OrderdetailsId))
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
            ViewData["OrderId"] = new SelectList(_context.Purchaseorders, "OrderId", "OrderId", purchaseorderdetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", purchaseorderdetail.ProductId);
            return View(purchaseorderdetail);
        }

        // GET: Purchaseorderdetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseorderdetail = await _context.Purchaseorderdetails
                .Include(p => p.Order)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.OrderdetailsId == id);
            if (purchaseorderdetail == null)
            {
                return NotFound();
            }

            return View(purchaseorderdetail);
        }

        // POST: Purchaseorderdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseorderdetail = await _context.Purchaseorderdetails.FindAsync(id);
            if (purchaseorderdetail != null)
            {
                _context.Purchaseorderdetails.Remove(purchaseorderdetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseorderdetailExists(int id)
        {
            return _context.Purchaseorderdetails.Any(e => e.OrderdetailsId == id);
        }
    }
}
