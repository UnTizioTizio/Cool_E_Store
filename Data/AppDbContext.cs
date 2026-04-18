using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoolEStore.Models;

namespace CoolEStore.Data;

public class AppDbContext : DbContext
{
    public DbSet<CoolEStore.Models.ProductModel> Products { get; set; } = default!;
    public DbSet<CoolEStore.Models.UserModel> Users { get; set; } = default!;
    public DbSet<CoolEStore.Models.OrderModel> Orders { get; set; } = default!;
    public DbSet<CoolEStore.Models.ReviewModel> Reviews { get; set; } = default!;
    public DbSet<CoolEStore.Models.ShoppingBasketRecordModel> ShoppingBasketRecords { get; set; } = default!;
    public DbSet<CoolEStore.Models.VendorModel> Vendors { get; set; } = default!;
    public DbSet<CoolEStore.Models.WarehouseRecordModel> WarehouseRecords { get; set; } = default!;

    public AppDbContext (DbContextOptions<AppDbContext> options)
        : base(options){}
}
