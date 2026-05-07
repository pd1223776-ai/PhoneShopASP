using PhoneShopMVC.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShopMVC.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCartItem> UserProductShoppingCarts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var deletedBooks = ChangeTracker.Entries<Product>()
                .Where(e => e.State == EntityState.Deleted);

            foreach (var bookEntry in deletedBooks)
            {
                var book = bookEntry.Entity;
                var imagePath = book.ImageUrl;
                if (string.IsNullOrEmpty(imagePath))
                {
                    continue;
                }
                DeleteBookImage(imagePath);
            }

            return await base.SaveChangesAsync();

        }

        public override int SaveChanges()
        {
            var deletedBooks = ChangeTracker.Entries<Product>()
                .Where(e => e.State == EntityState.Deleted);

            foreach (var bookEntry in deletedBooks)
            {
                var book = bookEntry.Entity;
                var imagePath = book.ImageUrl;
                if (string.IsNullOrEmpty(imagePath))
                {
                    continue;
                }
                DeleteBookImage(imagePath);
            }

            return base.SaveChanges();
        }

        private void DeleteBookImage(string? imagePath)
        {

            if (!File.Exists(imagePath))
            {
                return;
            }
            File.Delete(imagePath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
    new Category { Id = 1, Name = "iPhone", DisplayOrder = 1 },
    new Category { Id = 2, Name = "Samsung", DisplayOrder = 2 },
    new Category { Id = 3, Name = "Xiaomi", DisplayOrder = 3 },
    new Category { Id = 4, Name = "OPPO", DisplayOrder = 4 }
);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "iPhone 15 Pro Max",
                    Author = "Apple",
                    Description = "Điện thoại flagship cao cấp với chip A17 Pro, camera mạnh mẽ và màn hình Super Retina XDR.",
                    ISBN = "IP15PM256",
                    Price = 3200,
                    Price50 = 3100,
                    Price100 = 3000,
                    CategoryId = 1,
                    ImageUrl = "/images/product/36328942-bb61-4096-b720-5b9e16f2003e.jpg"
                },
                new Product
                {
                    Id = 2,
                    Title = "Samsung Galaxy S24 Ultra",
                    Author = "Samsung",
                    Description = "Smartphone Android cao cấp với bút S-Pen, camera zoom cực mạnh và AI thông minh.",
                    ISBN = "SSS24U512",
                    Price = 2900,
                    Price50 = 2800,
                    Price100 = 2700,
                    CategoryId = 2,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 3,
                    Title = "Xiaomi 14 Ultra",
                    Author = "Xiaomi",
                    Description = "Điện thoại hiệu năng cao với camera Leica chuyên nghiệp và sạc siêu nhanh.",
                    ISBN = "XM14U256",
                    Price = 2200,
                    Price50 = 2100,
                    Price100 = 2000,
                    CategoryId = 3,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 4,
                    Title = "OPPO Find X7 Ultra",
                    Author = "OPPO",
                    Description = "Thiết kế sang trọng, camera Hasselblad và màn hình AMOLED chất lượng cao.",
                    ISBN = "OPX7U256",
                    Price = 2400,
                    Price50 = 2300,
                    Price100 = 2200,
                    CategoryId = 4,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 5,
                    Title = "iPhone 14",
                    Author = "Apple",
                    Description = "iPhone thế hệ mới với hiệu năng ổn định, camera sắc nét và pin tối ưu.",
                    ISBN = "IP14256",
                    Price = 2100,
                    Price50 = 2000,
                    Price100 = 1900,
                    CategoryId = 1,
                    ImageUrl = ""
                },
                new Product
                {
                    Id = 6,
                    Title = "Samsung Galaxy A55",
                    Author = "Samsung",
                    Description = "Điện thoại tầm trung với màn hình đẹp, pin lớn và hiệu năng ổn định.",
                    ISBN = "SSA55256",
                    Price = 1200,
                    Price50 = 1150,
                    Price100 = 1100,
                    CategoryId = 2,
                    ImageUrl = ""
                }
            );
        }
    }
}
