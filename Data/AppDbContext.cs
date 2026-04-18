using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoolEStore.Models;

namespace CoolEStore.Data;

public class AppDbContext : DbContext
{
    public DbSet<CoolEStore.Models.ProductModel> ProductModel { get; set; } = default!;
    public DbSet<CoolEStore.Models.UserModel> UserModel { get; set; } = default!;
    public DbSet<CoolEStore.Models.OrderModel> OrderModel { get; set; } = default!;
    public DbSet<CoolEStore.Models.ReviewModel> ReviewModel { get; set; } = default!;
    public DbSet<CoolEStore.Models.ShoppingBasketRecordModel> ShoppingBasketRecordModel { get; set; } = default!;
    public DbSet<CoolEStore.Models.VendorModel> VendorModel { get; set; } = default!;
    public DbSet<CoolEStore.Models.WarehouseRecordModel> WarehouseRecordModel { get; set; } = default!;
    
    public AppDbContext (DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
