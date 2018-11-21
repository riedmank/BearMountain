using BearMountain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Data
{
    public class BearMountainDbContext : DbContext
    {
        public BearMountainDbContext(DbContextOptions<BearMountainDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 101,
                    SKU = "137913",
                    Name = "Arc'teryx Atom LT Insulated Hoodie",
                    Price = 259,
                    Description = "The Arc'teryx Atom LT Insulated hoodie featuring Coreloft™ insulation and air permeable side panels functions as an outer layer or as a mid layer depending on the conditions.",
                    Image = "arcteryxJacket.jpg"
                },
                new Product
                {
                    ID = 102,
                    SKU = "117155",
                    Name = "The North Face Furnace 20 Sleeping Bag",
                    Price = 189,
                    Description = "A lightweight, roomy design for 3-season backpacking, The North Face Furnace 20 sleeping bag is insulated with water-resistant ProDown, which repels water and dries faster than traditional down.",
                    Image = "northFaceBag.jpg"
                },
                new Product
                {
                    ID = 103,
                    SKU = "128692",
                    Name = "REI Co-op Half Dome 2 Plus Tent",
                    Price = 229,
                    Description = "Your home away from home shouldn't skimp on the essentials. The 3-season REI Co-op Half Dome 2 Plus backpacking tent provides you and a partner with plenty of room to stretch out and stay comfortable.",
                    Image = "reiTent.jpg"
                },
                new Product
                {
                    ID = 104,
                    SKU = "111284",
                    Name = "Osprey Aether AG 70 Pack ",
                    Price = 310,
                    Description = "For a long week on the trail or a gear - intensive weekend where extra volume is vital, the Osprey Aether AG 70 pack enhances mobility and comfort with the Anti - Gravity harness and suspended - mesh back.",
                    Image = "ospreyPack.jpg"
                },
                new Product
                {
                    ID = 105,
                    SKU = "867763",
                    Name = "Delta Kayaks Delta 14 Kayak",
                    Price = 1995,
                    Description = "Weighing in at a sleek 45 lbs., the Delta 14 Kayak with rudder from Delta Kayaks delivers speed and stability and offers tons of gear storage for weekend trips and extended tours.",
                    Image = "deltaKayak.jpg"
                },
                new Product
                {
                    ID = 106,
                    SKU = "120297",
                    Name = "MSR Lightning Ascent Snowshoes",
                    Price = 299,
                    Description = "The pinnacle of ultralight, aggressive all-terrain performance, MSR Lightning Ascent snowshoes offer tough, reliable decking for exploring mountainous winter wonderlands.",
                    Image = "msrSnowShoes.jpg"
                },
                new Product
                {
                    ID = 107,
                    SKU = "125922",
                    Name = "GHOST Kato FS 7.7 27.5 Bike",
                    Price = 2029,
                    Description = "Looking for a capable all-rounder for days on the mountain? The GHOST Kato FS 7.7 27.5 mountain bike offers full-suspension fun on a hydroformed aluminum frame.",
                    Image = "ghostBike.jpg"
                },
                new Product
                {
                    ID = 108,
                    SKU = "895931",
                    Name = "Black Diamond Trail Back Trekking Poles - Pair",
                    Price = 79,
                    Description = "The Black Diamond Trail Back trekking poles offer a reliable, easily adjustable, 3-section design for daily hikes and multiday adventures.",
                    Image = "blackMountainPoles.jpg"
                },
                new Product
                {
                    ID = 109,
                    SKU = "100106",
                    Name = "Hydro Flask Wide-Mouth Vacuum Water Bottle - 40 fl. oz.",
                    Price = 42,
                    Description = "The serious capacity on this Hydro Flask Wide-Mouth 40 oz. vacuum water bottle is perfect for all-day hydration (including ice cubes) or finishing your hike with hot soup.",
                    Image = "hydroFlask.jpg"
                },
                new Product
                {
                    ID = 110,
                    SKU = "887221",
                    Name = "Darn Tough Hiker Boot Sock Cushion Socks",
                    Price = 24,
                    Description = "With cushioning for the perfect amount of support and a smooth fit with no slipping, bunching, or blisters, the Darn Tough Hiker Boot Sock Cushion socks have earned a place in the hearts of hikers.",
                    Image = "socks.jpg"
                });

            modelBuilder.Entity<UserBasket>().HasData(
                new UserBasket
                {
                    ID = 1,
                    UserID = "jbc@bearmountain.com"
                });

            modelBuilder.Entity<BasketItem>().HasData(
                new BasketItem
                {
                    ID = 1, 
                    BasketID = 1,
                    ProductID = 110,
                    Quantity = 2,
                    CheckedOut = false
                });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UserBasket> UserBasket { get; set; }

    }
}
