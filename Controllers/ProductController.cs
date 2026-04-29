using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoolEStore.Data;
using CoolEStore.Models;
using CoolEStore.ViewModels;

namespace CoolEStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var products = await _context.Product
                .Include(p => p.Vendor)
                    .ThenInclude(v => v!.WarehouseRecords)
                .Include(p => p.Reviews)
                .AsSplitQuery()
                .ToListAsync();

            List<ProductViewModel> productViewModel = new List<ProductViewModel>(products.Count);
            products.ForEach(product => productViewModel.Add(
                new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    BasePrice = product.BasePrice,
                    Discount = product.Discount,
                    FinalPrice = product.FinalPrice,
                    Description = product.Description,
                    Category = product.Category,
                    Vendor = product.Vendor!,
                    Reviews = product.Reviews,
                    Amount = product.Vendor!.WarehouseRecords!
                                .Where(wr => wr.Id == product.Id)
                                .Select(wr => wr.Amount)
                                .FirstOrDefault(0)
                }
            ));
            return View(productViewModel.GroupBy(p => p.Category));
        } 

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Vendor)
                    .ThenInclude(v => v!.WarehouseRecords)
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ProductViewModel productViewModel = new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                BasePrice = product.BasePrice,
                Discount = product.Discount,
                FinalPrice = product.FinalPrice,
                Description = product.Description,
                Category = product.Category,
                Vendor = product.Vendor!,
                Reviews = product.Reviews,
                Amount = product.Vendor!.WarehouseRecords!
                            .Where(wr => wr.Id == product.Id)
                            .Select(wr => wr.Amount)
                            .FirstOrDefault(0)
            };

            return View(productViewModel);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BasePrice,Discount,Description,Category,VendorId")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Debug));
            }
            return View(productModel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Product.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }
            return View(productModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BasePrice,Discount,FinalPrice,Description,Category,VendorId")] ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelExists(productModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Debug));
            }
            return View(productModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productModel = await _context.Product.FindAsync(id);
            if (productModel != null)
            {
                _context.Product.Remove(productModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Debug));
        }

        private bool ProductModelExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Debug()
        {
            return View(await _context.Product.ToListAsync());
        }
    }
}
