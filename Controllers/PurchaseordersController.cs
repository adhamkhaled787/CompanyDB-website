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
    public class PurchaseordersController : Controller
    {
        private readonly CmpContext _context;

        public PurchaseordersController(CmpContext context)
        {
            _context = context;
        }

        // GET: Purchaseorders
        public async Task<IActionResult> Index()
        {
            var cmpContext = _context.Purchaseorders.Include(p => p.Vendor);
            return View(await cmpContext.ToListAsync());
        }

        // GET: Purchaseorders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseorder = await _context.Purchaseorders
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (purchaseorder == null)
            {
                return NotFound();
            }

            return View(purchaseorder);
        }

        // GET: Purchaseorders/Create
        public IActionResult Create()
        {
            ViewData["VendorId"] = new SelectList(_context.Vendors, "VendorId", "VendorId");
            return View();
        }

        // POST: Purchaseorders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,VendorId,PurchaseDate,Totalamount")] Purchaseorder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseorder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendorId"] = new SelectList(_context.Vendors, "VendorId", "VendorId", purchaseorder.VendorId);
            return View(purchaseorder);
        }

        // GET: Purchaseorders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseorder = await _context.Purchaseorders.FindAsync(id);
            if (purchaseorder == null)
            {
                return NotFound();
            }
            ViewData["VendorId"] = new SelectList(_context.Vendors, "VendorId", "VendorId", purchaseorder.VendorId);
            return View(purchaseorder);
        }

        // POST: Purchaseorders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,VendorId,PurchaseDate,Totalamount")] Purchaseorder purchaseorder)
        {
            if (id != purchaseorder.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseorder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseorderExists(purchaseorder.OrderId))
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
            ViewData["VendorId"] = new SelectList(_context.Vendors, "VendorId", "VendorId", purchaseorder.VendorId);
            return View(purchaseorder);
        }

        // GET: Purchaseorders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseorder = await _context.Purchaseorders
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (purchaseorder == null)
            {
                return NotFound();
            }

            return View(purchaseorder);
        }

        // POST: Purchaseorders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseorder = await _context.Purchaseorders.FindAsync(id);
            if (purchaseorder != null)
            {
                _context.Purchaseorders.Remove(purchaseorder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseorderExists(int id)
        {
            return _context.Purchaseorders.Any(e => e.OrderId == id);
        }
    }
}
