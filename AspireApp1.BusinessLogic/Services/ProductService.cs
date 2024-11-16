using AspireApp1.BusinessLogic.Repositories;
using AspireApp1.Models.Entities;

namespace AspireApp1.BusinessLogic.Services;

public interface IProductService {
    Task<List<ProductModel>> GetAllProducts();
    Task<ProductModel?> GetProductById(int id);
    Task UpdateProduct(int productId, ProductModel product);
    Task AddProduct(ProductModel product);
    Task DeleteProduct(int id);
}

public class ProductService : IProductService {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository) {
        _productRepository = productRepository;
    }

    public Task<List<ProductModel>> GetAllProducts() {
        return _productRepository.GetAllProducts();
    }

    public Task<ProductModel?> GetProductById(int id) {
        return _productRepository.GetProductById(id);
    }

    public Task UpdateProduct(int productId, ProductModel product) {
        return _productRepository.UpdateProduct(productId, product);
    }

    public Task AddProduct(ProductModel product) {
        return _productRepository.AddProduct(product);
    }

    public Task DeleteProduct(int id) {
        
        return _productRepository.DeleteProduct(id);
    }
}
