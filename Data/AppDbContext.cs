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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductModel>()
            .Property(p => p.FinalPrice)
            .HasComputedColumnSql("[BasePrice] * (1 - IFNULL([Discount], 0) / 100.0)");

        // Converts the ProductCategory enum to string and vice versa
        modelBuilder.Entity<ProductModel>()
            .Property(p => p.Category)
            .HasConversion(
                c => c.ToString(),
                c => (ProductCategory)Enum.Parse(typeof(ProductCategory), c)
            ); 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((context, _) =>
        {
            VendorModel[] vendors =
            {
                new VendorModel
                {
                    Name = "Absolute Cinema",
                    Email = "absolute.cinema@gmail.com",
                    Password = "pipopa",
                    PhoneNumber = "+393052165619",
                    CAP = "47012",
                    Address = "Via Bartolomeo II",
                    StreetNumber = 37
                },
                new VendorModel
                {
                    Name = "Power Gaming",
                    Email = "pwrgaming@gmail.com",
                    Password = "pipopa",
                    PhoneNumber = "+39327723416",
                    CAP = "37045",
                    Address = "Corso Buenos Aires",
                    StreetNumber = 2
                },
                new VendorModel
                {
                    Name = "Booking Smart",
                    Email = "booking.smart@gmail.com",
                    Password = "pipopa",
                    PhoneNumber = "+390964254011",
                    CAP = "44797",
                    Address = "Via Garibaldi",
                    StreetNumber = 246
                }
            };

            UserModel[] users =
            {
                new UserModel
                {
                    Username = "Admin_1",
                    Email = "admin01@gmail.com",
                    Password = "Password",
                    PhoneNumber = "+397777777777",
                    CAP = "33019",
                    Address = "Via Dante",
                    StreetNumber = 9
                },
                new UserModel
                {
                    Username = "Admin_2",
                    Email = "admin02@gmail.com",
                    Password = "Password",
                    PhoneNumber = "+394564564567",
                    CAP = "94019",
                    Address = "Via Umberto I",
                    StreetNumber = 95
                }
            };

            ProductModel[] products =
            {
                new ProductModel
                {
                    Name = "The Legend of Zelda: Twilight Princess",
                    BasePrice = 20.99m,
                    Discount = 14,
                    Description = "Best videogame ever made",
                    Category = ProductCategory.Videogames,
                    Vendor = vendors[1]
                },
                new ProductModel
                {
                    Name = "Dark Souls REMASTERED",
                    BasePrice = 45.99m,
                    Discount = 20,
                    Category = ProductCategory.Videogames,
                    Vendor = vendors[1]
                },
                new ProductModel
                {
                    Name = "Cyberpunk 2077",
                    BasePrice = 49.99m,
                    Discount = 0,
                    Description = "PEAK.",
                    Category = ProductCategory.Videogames,
                    Vendor = vendors[1]
                },
                new ProductModel
                {
                    Name = "Inglourious Basterds",
                    BasePrice = 9.99m,
                    Category = ProductCategory.Movies,
                    Vendor = vendors[0]
                },
                new ProductModel
                {
                    Name = "Blood Meridian",
                    BasePrice = 15.49m,
                    Discount = 13,
                    Category = ProductCategory.Books,
                    Vendor = vendors[2]
                }
            };

            ReviewModel[] reviews =
            {
                new ReviewModel
                {
                    NStars = 4,
                    User = users[0],
                    Product = products[1]
                },
                new ReviewModel
                {
                    NStars = 5,
                    User = users[0],
                    Product = products[0]
                },
                new ReviewModel
                {
                    NStars = 2,
                    User = users[1],
                    Product = products[1]
                }
            };

            AppDbContext appDbContext = (AppDbContext)context;
            
            if(!appDbContext.Set<VendorModel>().Any()) 
                appDbContext.Vendor.AddRange(vendors);
            
            if(!appDbContext.Set<UserModel>().Any())
                appDbContext.User.AddRange(users);
            
            if(!appDbContext.Set<ProductModel>().Any())
                appDbContext.Product.AddRange(products);
            
            if(!appDbContext.Set<ReviewModel>().Any())
                appDbContext.Review.AddRange(reviews);

            appDbContext.SaveChanges();
        });
    }
}
