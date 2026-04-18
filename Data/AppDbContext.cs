using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoolEStore.Models;

namespace CoolEStore.Data;

public class AppDbContext : DbContext
{
    public DbSet<CoolEStore.Models.ProductModel> Product { get; set; } = default!;
    public DbSet<CoolEStore.Models.UserModel> User { get; set; } = default!;
    public DbSet<CoolEStore.Models.OrderModel> Order { get; set; } = default!;
    public DbSet<CoolEStore.Models.ReviewModel> Review { get; set; } = default!;
    public DbSet<CoolEStore.Models.ShoppingBasketRecordModel> ShoppingBasketRecord { get; set; } = default!;
    public DbSet<CoolEStore.Models.VendorModel> Vendor { get; set; } = default!;
    public DbSet<CoolEStore.Models.WarehouseRecordModel> WarehouseRecord { get; set; } = default!;

    public AppDbContext (DbContextOptions<AppDbContext> options)
        : base(options){}
}
