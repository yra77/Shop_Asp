

using Shop_Asp.Models;
using Shop_Asp.Domain.Entities;
using Shop_Asp.Domain.Helpers;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Shop_Asp.Domain
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Brand> Brands { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Login> Logins { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Photo> Photos { get; set; } = null!;
        public DbSet<ShopModel> ShopModels { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
             Database.EnsureCreated();   // создаем базу данных при первом обращении
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Cart>().ToTable("Carts");
            modelBuilder.Entity<Login>().ToTable("Logins");
            modelBuilder.Entity<Photo>().ToTable("Photos");
            modelBuilder.Entity<Product>().ToTable("Products");
    //.HasMany<Photo>(g => g.Photos_Large)
    //.WithOne(s => s.Product)
    //.OnDelete(DeleteBehavior.Cascade)
    //.IsRequired();
            modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<ShopModel>().ToTable("ShopModels");

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });

           // SetProducts(modelBuilder);

            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 1,
                LogoBrands = "~/wwwroot/Images/ic_nike.png",
                NameBrand = "nike"
            });

            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 2,
                LogoBrands = "~/wwwroot/Images/ic_adidas.png",
                NameBrand = "adidas"
            });

            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 3,
                LogoBrands = "~/wwwroot/Images/ic_puma.png",
                NameBrand = "puma"
            });

            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 4,
                LogoBrands = "~/wwwroot/Images/ic_nb.png",
                NameBrand = "nb"
            });


            modelBuilder.Entity<ShopModel>().HasData(new ShopModel()
            {
                Id = 1,
                Title = "Shop",
                CompanyName = "Shop",
                CompanyEmail = "shop@aa.aa",
                CompanyPhone = "+380 00 000 00 00",
                DescriptionCompany = "Shop snikers",
                LogoImgPath = "~/Images/logo.png",
                MetaTitle = "Shop snickers",
                MetaDescription = "buy snickers adidas nike puma nb new balance купити " +
                                  "кросівки адидас найк пума нб ньюбаланс магазин shop",
                MetaKeywords = "snickers adidas nike puma nb new balance кросівки " +
                               "адидас найк пума нб ньюбаланс магазин shop"

            });
        }

        private void SetProducts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Brand = "Puma",
                Colors = "White Pink Gray",
                Count = 7,
                Date = DateTime.Now,
                DescriptionEn = "Puma woomens spring shoes",
                DescriptionUa = "Жіноче весняне взуття Puma",
                Gender = "w",
                IsBestSeller = true,
                IsNew = true,
                Name = "Puma Woomen",
                Price = 150,
                Sizes = "37 38",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\puma\\1a.webp " +
                                                  "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\puma\\2a.jpg " +
                                                  "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\puma\\3a.jpg", 1)
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Brand = "Puma",
                Colors = "White Black",
                Count = 18,
                Date = DateTime.Now,
                DescriptionEn = "Good shoes",
                DescriptionUa = "Гарне взуття",
                Gender = "m",
                IsBestSeller = false,
                IsNew = false,
                Name = "Puma Air men",
                Price = 190,
                Sizes = "42 44",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\puma\\1b.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\puma\\2b.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\puma\\3b.webp", 2),
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Brand = "Puma",
                Colors = "Red",
                Count = 5,
                Date = DateTime.Now,
                DescriptionEn = "Good spring shoes",
                DescriptionUa = "Гарне весняне взуття",
                Gender = "u",
                IsBestSeller = false,
                IsNew = true,
                Name = "Puma Red",
                Price = 265,
                Sizes = "37 38 39 41 42",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\puma\\1c.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\puma\\2c.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\puma\\3c.webp", 3),
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Brand = "Adidas",
                Colors = "White Green Gray",
                Count = 7,
                Date = DateTime.Now,
                DescriptionEn = "Adidas woomens spring shoes",
                DescriptionUa = "Adidas жіноче весняне взуття",
                Gender = "w",
                IsBestSeller = true,
                IsNew = true,
                Name = "Adidas Woomen",
                Price = 190,
                Sizes = "37 38",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\adidas\\1a.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\adidas\\2a.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\adidas\\3a.webp", 4)
        });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Brand = "Adidas",
                Colors = "White Black",
                Count = 18,
                Date = DateTime.Now,
                DescriptionEn = "Adidas Good shoes",
                DescriptionUa = "Adidas гарне взуття",
                Gender = "m",
                IsBestSeller = true,
                IsNew = false,
                Name = "Adidas Men",
                Price = 170,
                Sizes = "42 44",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\adidas\\1b.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\adidas\\2b.jpg " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\adidas\\3b.webp", 5),
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 6,
                Brand = "Adidas",
                Colors = "White",
                Count = 5,
                Date = DateTime.Now,
                DescriptionEn = "Good spring shoes",
                DescriptionUa = "Гарне весняне взуття",
                Gender = "w",
                IsBestSeller = false,
                IsNew = true,
                Name = "Adidas",
                Price = 125,
                Sizes = "37 38 39",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\adidas\\1c.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\adidas\\2c.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\adidas\\3c.jpg", 6),
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 7,
                Brand = "New Balance",
                Colors = "Black Blue Gray",
                Count = 7,
                Date = DateTime.Now,
                DescriptionEn = "New Balance mens spring shoes",
                DescriptionUa = "New Balance чоловіче весняне взуття",
                Gender = "m",
                IsBestSeller = true,
                IsNew = true,
                Name = "New Balance 848",
                Price = 180,
                Sizes = "41 42 43 44",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nb\\1a.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nb\\2a.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nb\\3a.webp", 7),
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 8,
                Brand = "New Balance",
                Colors = "White Red White",
                Count = 3,
                Date = DateTime.Now,
                DescriptionEn = "New Balance Good shoes",
                DescriptionUa = "New Balance гарне взуття",
                Gender = "u",
                IsBestSeller = true,
                IsNew = true,
                Name = "New Balance",
                Price = 200,
                Sizes = "38 40 42 43",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nb\\1b.jpg " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nb\\2b.jpg " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nb\\3b.jpg", 8),
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 9,
                Brand = "New Balance",
                Colors = "Black White",
                Count = 15,
                Date = DateTime.Now,
                DescriptionEn = "Good spring shoes",
                DescriptionUa = "Гарне весняне взуття",
                Gender = "u",
                IsBestSeller = false,
                IsNew = false,
                Name = "New Balance 756",
                Price = 150,
                Sizes = "37 38 39 41 44",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nb\\1c.jpg " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nb\\2c.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nb\\3c.jpg", 9),
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 10,
                Brand = "Nike",
                Colors = "Black Red White",
                Count = 7,
                Date = DateTime.Now,
                DescriptionEn = "Nike mens spring shoes",
                DescriptionUa = "Nike mens весняне взуття",
                Gender = "m",
                IsBestSeller = false,
                IsNew = true,
                Name = "Nike Air",
                Price = 210,
                Sizes = "42 43 44",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nike\\1a.jpeg " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nike\\2a.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nike\\3a.jpg", 10),
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 11,
                Brand = "Nike",
                Colors = "White",
                Count = 5,
                Date = DateTime.Now,
                DescriptionEn = "Nike Good shoes",
                DescriptionUa = "Nike гарне взуття",
                Gender = "u",
                IsBestSeller = true,
                IsNew = true,
                Name = "Nike Air2",
                Price = 210,
                Sizes = "37 38 40 41",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nike\\1b.jpeg " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nike\\2b.jpg " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nike\\3b.webp", 11),
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 12,
                Brand = "Nike",
                Colors = "Black White Gray",
                Count = 9,
                Date = DateTime.Now,
                DescriptionEn = "Good winter shoes",
                DescriptionUa = "Гарне зимове взуття",
                Gender = "m",
                IsBestSeller = false,
                IsNew = true,
                Name = "Nike Air Winter",
                Price = 250,
                Sizes = "41 43 44",
                Photos_Large = PathToByteArray.GetList("C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nike\\1c.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nike\\2c.webp " +
                    "C:\\Users\\User\\source\\repos\\WebApi\\bin\\Debug\\net6.0\\Shoes\\nike\\3c.jpg", 12),
            });
        }

    }
}
