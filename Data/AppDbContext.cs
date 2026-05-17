using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoolEStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CoolEStore.Data;

public class AppDbContext : IdentityDbContext<ApplicationUserModel, IdentityRole<int>, int>
{
    public DbSet<ApplicationUserModel> ApplicationUser { get; set; } = default!;
    public DbSet<CustomerModel> Customer { get; set; } = default!;
    public DbSet<VendorModel> Vendor { get; set; } = default!;
    public DbSet<ProductModel> Product { get; set; } = default!;
    public DbSet<OrderModel> Order { get; set; } = default!;
    public DbSet<ReviewModel> Review { get; set; } = default!;
    public DbSet<ShoppingBasketRecordModel> ShoppingBasketRecord { get; set; } = default!;
    public DbSet<WarehouseRecordModel> WarehouseRecord { get; set; } = default!;

    public AppDbContext (DbContextOptions<AppDbContext> options)
        : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        var productModel = modelBuilder.Entity<ProductModel>();
        
        productModel
            .Property(p => p.FinalPrice)
            .HasComputedColumnSql("ROUND([BasePrice] * (1 - IFNULL([Discount], 0) / 100.0), 2)");

        // Converts the ProductCategory enum to string and vice versa
        productModel
            .Property(p => p.Category)
            .HasConversion(
                c => c.ToString(),
                c => (ProductCategory)Enum.Parse(typeof(ProductCategory), c)
            );

        var applicationUserModel = modelBuilder.Entity<ApplicationUserModel>();
        
        // Converts the UserType enum to string and vice versa
        applicationUserModel
            .Property(a => a.Type)
            .IsRequired()
            .HasConversion(
                t => t.ToString(),
                t => (UserType)Enum.Parse(typeof(UserType), t)
            );

        applicationUserModel.HasIndex(a => a.Email).IsUnique();
        applicationUserModel.HasIndex(a => a.PhoneNumber).IsUnique();
        
        applicationUserModel.Property(a => a.Email).IsRequired();
        applicationUserModel.Property(a => a.UserName).IsRequired();
        applicationUserModel.Property(a => a.PhoneNumber).IsRequired();
        applicationUserModel.Property(a => a.PasswordHash).IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSeeding((context, _) =>
        {
            ApplicationUserModel[] applicationUsers = SeedUsers.GetSeededUsers().ToArray();

            VendorModel[] vendors =
            {
                new VendorModel{ ApplicationUser = applicationUsers[2] },
                new VendorModel{ ApplicationUser = applicationUsers[3] },
                new VendorModel{ ApplicationUser = applicationUsers[4] }
            };

            CustomerModel[] customers =
            {
                new CustomerModel{ ApplicationUser = applicationUsers[0] },
                new CustomerModel{ ApplicationUser = applicationUsers[1] }
            };

            const string PRODUCT_IMAGE_PATH = "/images/products/";
            ProductModel[] products =
            {
/* ========================== Videogames ========================== */
                new ProductModel
                {
                    Name = "The Legend of Zelda: Twilight Princess",
                    BasePrice = 20.99m,
                    Discount = 14,
                    Description = "A dark and atmospheric masterpiece in the Zelda series. Players guide Link through the land of Hyrule and the shadowy Twilight Realm, switching between human and wolf forms to solve puzzles, battle creatures, and uncover a sinister plot. Praised for its epic dungeon design, gripping story, and the unforgettable companion Midna, it remains one of the most beloved entries in the franchise.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "twilight_princess.jpg",
                    Category = ProductCategory.Videogames,
                    Vendor = vendors[1]
                },
                new ProductModel
                {
                    Name = "Dark Souls REMASTERED",
                    BasePrice = 45.99m,
                    Discount = 20,
                    Description = "The genre-defining action RPG returns with enhanced visuals and improved performance. Descend into the cursed kingdom of Lordran, where death is a teacher, not a failure. With methodical combat, intricate level design, and lore buried in item descriptions, every victory is earned through patience and skill. Prepare to die — and to triumph.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "dark_souls_remastered.jpg",
                    Category = ProductCategory.Videogames,
                    Vendor = vendors[1]
                },
                new ProductModel
                {
                    Name = "Cyberpunk 2077",
                    BasePrice = 49.99m,
                    Discount = 0,
                    Description = "Step into Night City, a sprawling megalopolis obsessed with power, glamour, and body modification. As mercenary V, you chase a one-of-a-kind implant that holds the key to immortality. With deep character customization, branching storylines, and a vast open world, it's a tale of survival in a future where the line between humanity and technology has blurred beyond recognition.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "cyberpunk_2077.jpg",
                    Category = ProductCategory.Videogames,
                    Vendor = vendors[1]
                },
                new ProductModel
                {
                    Name = "Outer Wilds",
                    BasePrice = 24.99m,
                    Discount = 8,
                    Description = "A fantastic space journey awaits you. Explore a handcrafted solar system trapped in an endless time loop, where each planet hides secrets of an ancient alien race. With nothing but a translator and a rickety spaceship, you piece together a cosmic mystery one loop at a time. It's a game about curiosity, discovery, and the quiet beauty of the universe.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "outer_wilds.jpg",
                    Category = ProductCategory.Videogames,
                    Vendor = vendors[1]
                },
                new ProductModel
                {
                    Name = "Hollow Knight: Silksong",
                    BasePrice = 19.99m,
                    Discount = 13,
                    Description = "Very cute, also very dark. Hornet, princess-protector of Hallownest, awakens in a new kingdom ruled by silk and song. With acrobatic combat, fluid platforming, and a hauntingly beautiful world, this sequel expands the beloved Hollow Knight formula. Ascend through mossy grottoes, gleaming citadels, and ashen wastes in a challenging quest to reach the shining citadel above.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "hollow_knight_silksong.jpg",
                    Category = ProductCategory.Videogames,
                    Vendor = vendors[1]
                },
/* ========================== Movies ========================== */
                new ProductModel
                {
                    Name = "Inglourious Basterds",
                    BasePrice = 9.99m,
                    Description = @"Quentin Tarantino's audacious World War II reimagining follows two parallel assassination plots against the Nazi high command. A Jewish cinema owner in occupied France and a squad of Jewish-American soldiers nicknamed ""The Basterds"" both target the same event. Tense dialogue, explosive action, and Christoph Waltz's terrifying performance as Colonel Hans Landa make this a modern classic.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "inglourious_basterds.jpg",
                    Category = ProductCategory.Movies,
                    Vendor = vendors[0]
                },
                new ProductModel
                {
                    Name = "Cast Away",
                    BasePrice = 9.99m,
                    Discount = 4,
                    Description = "Tom Hanks delivers a career-defining performance as Chuck Noland, a FedEx executive stranded on a deserted island after a plane crash. With only a volleyball named Wilson for company, he must learn to survive in total isolation. More than a survival story, it's a meditation on time, hope, and what it means to be human when everything is stripped away.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "cast_away.jpg",
                    Category = ProductCategory.Movies,
                    Vendor = vendors[0]
                },
                new ProductModel
                {
                    Name = "Interstellar",
                    BasePrice = 13.99m,
                    Description = "From Christopher Nolan comes a mind-bending journey through a wormhole in search of a new home for humanity. A former NASA pilot leaves his family behind to join an expedition across galaxies, where time itself becomes the enemy. Visually stunning and emotionally devastating, it explores love, sacrifice, and survival on a cosmic scale.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "interstellar.jpg",
                    Category = ProductCategory.Movies,
                    Vendor = vendors[0]
                },
                new ProductModel
                {
                    Name = "The Truman Show",
                    BasePrice = 8.59m,
                    Discount = 5,
                    Description = "Truman Burbank lives a seemingly idyllic life — except every moment is broadcast live to a global audience without his knowledge. His entire world is a massive television set. As cracks appear in the illusion, Truman begins to question everything. Jim Carrey shines in this prescient dramedy about media, control, and the courage to break free from a comfortable lie.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "the_truman_show.jpg",
                    Category = ProductCategory.Movies,
                    Vendor = vendors[0]
                },
                new ProductModel
                {
                    Name = "Fight Club",
                    BasePrice = 9.99m,
                    Discount = 7,
                    Description = "A disillusioned office worker forms an underground fight club with a charismatic soap salesman, and things spiral far beyond control. Raw, satirical, and relentless, David Fincher's adaptation of Chuck Palahniuk's novel dissects modern masculinity, consumer culture, and the search for identity. It's a film that refuses to pull its punches — and you don't talk about it.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "fight_club.jpg",
                    Category = ProductCategory.Movies,
                    Vendor = vendors[0]
                },
/* ========================== Books ========================== */
                new ProductModel
                {
                    Name = "1984",
                    BasePrice = 11.87m,
                    Description = "George Orwell's chilling vision of a totalitarian future where Big Brother watches everything and the Thought Police crush dissent. Winston Smith dares to question the Party's absolute control over truth, language, and even thought itself. A novel that defined dystopian fiction, its warnings about surveillance and propaganda feel more urgent with each passing year.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "1984.jpg",
                    Category = ProductCategory.Books,
                    Vendor = vendors[2]
                },
                new ProductModel
                {
                    Name = "Blood Meridian",
                    BasePrice = 15.49m,
                    Discount = 13,
                    Description = @"Cormac McCarthy's brutal, biblical masterpiece follows a nameless teenager known only as ""the kid"" through the blood-soaked borderlands of the 1850s American West. With the scalp-hunting Glanton gang and the terrifying Judge Holden, it explores violence, fate, and the darkest corners of human nature. Unflinching prose and philosophical depth make it one of the greatest American novels.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "blood_meridian.jpg",
                    Category = ProductCategory.Books,
                    Vendor = vendors[2]
                },
                new ProductModel
                {
                    Name = "C# 12 in a Nutshell",
                    BasePrice = 60.22m,
                    Discount = 22,
                    Description = "This book is a must-have if you want to learn C# in 2023. A definitive reference that covers every aspect of the language, from basic syntax to advanced topics like LINQ, asynchronous programming, and memory management. Whether you're a beginner or an experienced developer, it's the essential companion for mastering C# and the .NET ecosystem.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "c_sharp_12.jpg",
                    Category = ProductCategory.Books,
                    Vendor = vendors[2]
                },
                new ProductModel
                {
                    Name = "The Art of Game Design: A Book of Lenses, Third Edition",
                    BasePrice = 72.49m,
                    Discount = 2,
                    Description = @"The Art of Game Design guides you through the design process step-by-step, 
                    helping you to develop new and innovative games that will be played again and again. It 
                    explains the fundamental principles of game design and demonstrates how tactics used in 
                    classic board, card and athletic games also work in top-quality video games.",
                    ImageUrl = PRODUCT_IMAGE_PATH + "the_art_of_game_design.jpg",
                    Category = ProductCategory.Books,
                    Vendor = vendors[2]
                },
            };

            ReviewModel[] reviews =
            {
                new ReviewModel
                {
                    NStars = 4,
                    Customer = customers[0],
                    Product = products[1]
                },
                new ReviewModel
                {
                    NStars = 5,
                    Customer = customers[0],
                    Product = products[0]
                },
                new ReviewModel
                {
                    NStars = 2,
                    Customer = customers[1],
                    Product = products[1]
                }
            };

            Random rand = new Random();
            WarehouseRecordModel[] warehouseRecords =
            {
/* ========================== Videogames ========================== */
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[0],
                    Vendor = vendors[1]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[1],
                    Vendor = vendors[1]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[2],
                    Vendor = vendors[1]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[3],
                    Vendor = vendors[1]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[4],
                    Vendor = vendors[1]
                },
/* ========================== Movies ========================== */
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[5],
                    Vendor = vendors[0]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[6],
                    Vendor = vendors[0]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[7],
                    Vendor = vendors[0]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[8],
                    Vendor = vendors[0]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[9],
                    Vendor = vendors[0]
                },
/* ========================== Books ========================== */
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[10],
                    Vendor = vendors[2]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[11],
                    Vendor = vendors[2]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[12],
                    Vendor = vendors[2]
                },
                new WarehouseRecordModel
                {
                    Amount = (int)rand.NextInt64(5, 9999),
                    Product = products[13],
                    Vendor = vendors[2]
                }
            };

            AppDbContext appDbContext = (AppDbContext)context;
            
            if(!appDbContext.Set<ApplicationUserModel>().Any())
                appDbContext.ApplicationUser.AddRange(applicationUsers);

            if(!appDbContext.Set<VendorModel>().Any()) 
                appDbContext.Vendor.AddRange(vendors);
            
            if(!appDbContext.Set<CustomerModel>().Any())
                appDbContext.Customer.AddRange(customers);
            
            if(!appDbContext.Set<ProductModel>().Any())
                appDbContext.Product.AddRange(products);
            
            if(!appDbContext.Set<ReviewModel>().Any())
                appDbContext.Review.AddRange(reviews);

            if(!appDbContext.Set<WarehouseRecordModel>().Any())
                appDbContext.WarehouseRecord.AddRange(warehouseRecords);

            appDbContext.SaveChanges();
        });
    }
}
