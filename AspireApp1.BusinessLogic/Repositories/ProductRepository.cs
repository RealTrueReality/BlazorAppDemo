using AspireApp1.Database.Data;
using AspireApp1.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspireApp1.BusinessLogic.Repositories;

public interface IProductRepository {
    Task<List<ProductModel>> GetAllProducts();
    Task<ProductModel?> GetProductById(int id);
    Task UpdateProduct(int productId, ProductModel product);
    Task AddProduct(ProductModel product);
    Task DeleteProduct(int id);
}

public class ProductRepository : IProductRepository {
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext) {
        _dbContext = dbContext;
    }
    public async Task<List<ProductModel>> GetAllProducts() {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<ProductModel?> GetProductById(int id) {
        return  await _dbContext.Products.FindAsync(id);
    }

    public async Task UpdateProduct(int productId, ProductModel product) {
        if (product is null) return;
        if (product.Id != productId) return;
        var productFound  =await _dbContext.Products.FindAsync(productId);
        if (productFound is null) return;
        productFound.ProductName = product.ProductName;
        productFound.Price = product.Price;
        productFound.Description = product.Description;
        productFound.Quantity = product.Quantity;
        productFound.CreateTime = product.CreateTime;
        _dbContext.Products.Update(productFound);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddProduct(ProductModel product) {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id) {
        var productModel = await _dbContext.Products.FindAsync(id);
        if (productModel is null) return;
        _dbContext.Products.Remove(productModel);
        await _dbContext.SaveChangesAsync();
    }
}