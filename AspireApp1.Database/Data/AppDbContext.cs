using AspireApp1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.Database.Data;

public class AppDbContext : DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions) {
    }

    public DbSet<ProductModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<ProductModel>().HasData(
            new ProductModel {
                Id = 1,
                ProductName = "Product 1",
                Quantity = 10,
                Price = 100,
                Description = "This is product 1",
                CreateTime = DateTime.Now
            },
            new ProductModel {
                Id = 2,
                ProductName = "Product 2",
                Quantity = 20,
                Price = 200,
                Description = "This is product 2",
                CreateTime = DateTime.Now
            },
            new ProductModel {
                Id = 3,
                ProductName = "Product 3",
                Quantity = 30,
                Price = 300,
                Description = "This is product 3",
                CreateTime = DateTime.Now
            }
        );
    }
}