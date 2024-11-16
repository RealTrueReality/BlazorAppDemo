using AspireApp1.BusinessLogic.Services;
using AspireApp1.Models.Entities;
using AspireApp1.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspireApp1.ApiService.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase {
    private readonly IProductService _productService;

    public ProductController(IProductService productService) {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProducts() {
        var products = await _productService.GetAllProducts();
        return Ok(new BaseResponseModel { IsSuccess = true, Data = products });
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetProductById(int id) {
        var product = await _productService.GetProductById(id);
        return Ok(new BaseResponseModel { IsSuccess = true, Data = product });
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(int id,[FromBody]ProductModel product) {
        await _productService.UpdateProduct(id,product);
        return Ok(new BaseResponseModel { IsSuccess = true, Message = "Update Successfully" });
    }
    //add
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody]ProductModel product) {
        await _productService.AddProduct(product);
        return Ok(new BaseResponseModel { IsSuccess = true, Message = "Add Successfully" });
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id) {
        await _productService.DeleteProduct(id);
        return Ok(new BaseResponseModel { IsSuccess = false, Message = "Delete Successfully" });
    }
}