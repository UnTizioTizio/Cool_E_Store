using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoolEStore.Models;

namespace CoolEStore.Data;

public class AppDbContext : DbContext
{
    public DbSet<ProductModel> Product { get; set; } = default!;
    public DbSet<UserModel> User { get; set; } = default!;
    public DbSet<OrderModel> Order { get; set; } = default!;
    public DbSet<ReviewModel> Review { get; set; } = default!;
    public DbSet<ShoppingBasketRecordModel> ShoppingBasketRecord { get; set; } = default!;
    public DbSet<VendorModel> Vendor { get; set; } = default!;
    public DbSet<WarehouseRecordModel> WarehouseRecord { get; set; } = default!;

    public AppDbContext (DbContextOptions<AppDbContext> options)
        : base(options){}
}
