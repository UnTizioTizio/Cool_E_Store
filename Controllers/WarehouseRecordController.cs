using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoolEStore.Data;
using CoolEStore.Models;

namespace CoolEStore.Controllers
{
    public class WarehouseRecordController : Controller
    {
        private readonly AppDbContext _context;

        public WarehouseRecordController(AppDbContext context)
        {
            _context = context;
        }

        // GET: WarehouseRecord
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.WarehouseRecord.Include(w => w.Product).Include(w => w.Vendor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: WarehouseRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouseRecordModel = await _context.WarehouseRecord
                .Include(w => w.Product)
                .Include(w => w.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouseRecordModel == null)
            {
                return NotFound();
            }

            return View(warehouseRecordModel);
        }

        // GET: WarehouseRecord/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "Id");
            return View();
        }

        // POST: WarehouseRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,ProductId,VendorId")] WarehouseRecordModel warehouseRecordModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warehouseRecordModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", warehouseRecordModel.ProductId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "Id", warehouseRecordModel.VendorId);
            return View(warehouseRecordModel);
        }

        // GET: WarehouseRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouseRecordModel = await _context.WarehouseRecord.FindAsync(id);
            if (warehouseRecordModel == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", warehouseRecordModel.ProductId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "Id", warehouseRecordModel.VendorId);
            return View(warehouseRecordModel);
        }

        // POST: WarehouseRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,ProductId,VendorId")] WarehouseRecordModel warehouseRecordModel)
        {
            if (id != warehouseRecordModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warehouseRecordModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseRecordModelExists(warehouseRecordModel.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", warehouseRecordModel.ProductId);
            ViewData["VendorId"] = new SelectList(_context.Vendor, "Id", "Id", warehouseRecordModel.VendorId);
            return View(warehouseRecordModel);
        }

        // GET: WarehouseRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var warehouseRecordModel = await _context.WarehouseRecord
                .Include(w => w.Product)
                .Include(w => w.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouseRecordModel == null)
            {
                return NotFound();
            }

            return View(warehouseRecordModel);
        }

        // POST: WarehouseRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var warehouseRecordModel = await _context.WarehouseRecord.FindAsync(id);
            if (warehouseRecordModel != null)
            {
                _context.WarehouseRecord.Remove(warehouseRecordModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarehouseRecordModelExists(int id)
        {
            return _context.WarehouseRecord.Any(e => e.Id == id);
        }
    }
}
