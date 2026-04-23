using CoolEStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoolEStore.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
        {
            if(!context.Product.Any())
            {
                context.Product.AddRange(
                    new ProductModel
                    {
                        Id = 1,
                        Name = "The Legend of Zelda: Twilight Princess",
                        BasePrice = 20.99m,
                        Discount = 14,
                        Description = "Best videogame ever made",
                        Category = ProductCategory.Videogames,
                        VendorId = 5
                    },
                    new ProductModel
                    {
                        Id = 2,
                        Name = "Dark Souls REMASTERED",
                        BasePrice = 45.99m,
                        Discount = 20,
                        Category = ProductCategory.Videogames,
                        VendorId = 5
                    },
                    new ProductModel
                    {
                        Id = 3,
                        Name = "Cyberpunk 2077",
                        BasePrice = 49.99m,
                        Discount = 0,
                        Description = "PEAK.",
                        Category = ProductCategory.Videogames,
                        VendorId = 5
                    },
                    new ProductModel
                    {
                        Id = 4,
                        Name = "Inglourious Basterds",
                        BasePrice = 9.99m,
                        Category = ProductCategory.Movies,
                        VendorId = 89
                    },
                    new ProductModel
                    {
                        Id = 5,
                        Name = "Blood Meridian",
                        BasePrice = 15.49m,
                        Discount = 13,
                        Category = ProductCategory.Books,
                        VendorId = 23
                    }
                );
            }

            if(!context.Order.Any())
            {
                
            }

            if(!context.Review.Any())
            {
                context.Review.AddRange(
                    new ReviewModel
                    {
                        NStars = 4,
                        UserId = 1,
                        ProductId = 3
                    },
                    new ReviewModel
                    {
                        NStars = 5,
                        UserId = 1,
                        ProductId = 1
                    },
                    new ReviewModel
                    {
                        NStars = 2,
                        UserId = 2,
                        ProductId = 1
                    }
                );
            }

            if(!context.User.Any())
            {
                context.User.AddRange(
                    new UserModel
                    {
                        Id = 1,
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
                        Id = 2,
                        Username = "Admin_2",
                        Email = "admin02@gmail.com",
                        Password = "Password",
                        PhoneNumber = "+394564564567",
                        CAP = "94019",
                        Address = "Via Umberto I",
                        StreetNumber = 95
                    }
                );
            }

            if(!context.Vendor.Any())
            {
                context.Vendor.AddRange(
                    new VendorModel
                    {
                        Id = 89,
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
                        Id = 5,
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
                        Id = 23,
                        Name = "Booking Smart",
                        Email = "booking.smart@gmail.com",
                        Password = "pipopa",
                        PhoneNumber = "+390964254011",
                        CAP = "44797",
                        Address = "Via Garibaldi",
                        StreetNumber = 246
                    }
                );
            }

            if(!context.ShoppingBasketRecord.Any())
            {
                
            }

            if(!context.WarehouseRecord.Any())
            {
                
            }
        }
    }
}