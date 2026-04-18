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
    public class ShoppingBasketRecordController : Controller
    {
        private readonly AppDbContext _context;

        public ShoppingBasketRecordController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingBasketRecord
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ShoppingBasketRecords.Include(s => s.Product).Include(s => s.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: ShoppingBasketRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingBasketRecordModel = await _context.ShoppingBasketRecords
                .Include(s => s.Product)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingBasketRecordModel == null)
            {
                return NotFound();
            }

            return View(shoppingBasketRecordModel);
        }

        // GET: ShoppingBasketRecord/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: ShoppingBasketRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,UserId")] ShoppingBasketRecordModel shoppingBasketRecordModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingBasketRecordModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", shoppingBasketRecordModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", shoppingBasketRecordModel.UserId);
            return View(shoppingBasketRecordModel);
        }

        // GET: ShoppingBasketRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingBasketRecordModel = await _context.ShoppingBasketRecords.FindAsync(id);
            if (shoppingBasketRecordModel == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", shoppingBasketRecordModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", shoppingBasketRecordModel.UserId);
            return View(shoppingBasketRecordModel);
        }

        // POST: ShoppingBasketRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,UserId")] ShoppingBasketRecordModel shoppingBasketRecordModel)
        {
            if (id != shoppingBasketRecordModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingBasketRecordModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingBasketRecordModelExists(shoppingBasketRecordModel.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", shoppingBasketRecordModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", shoppingBasketRecordModel.UserId);
            return View(shoppingBasketRecordModel);
        }

        // GET: ShoppingBasketRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingBasketRecordModel = await _context.ShoppingBasketRecords
                .Include(s => s.Product)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingBasketRecordModel == null)
            {
                return NotFound();
            }

            return View(shoppingBasketRecordModel);
        }

        // POST: ShoppingBasketRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingBasketRecordModel = await _context.ShoppingBasketRecords.FindAsync(id);
            if (shoppingBasketRecordModel != null)
            {
                _context.ShoppingBasketRecords.Remove(shoppingBasketRecordModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingBasketRecordModelExists(int id)
        {
            return _context.ShoppingBasketRecords.Any(e => e.Id == id);
        }
    }
}
