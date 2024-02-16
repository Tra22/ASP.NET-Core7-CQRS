using CQRS.Payloads.Requests.Products;
using CQRS.Payloads.Responses.Products;
using CQRS.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }
    [HttpGet]
    public async Task<List<ProductResponse>> GetAllProducts(){
        return await _productService.GetAllProductsAsync();
    }
    [HttpGet("{Id}")]
    public async Task<ProductResponse> GetProductById(int Id){
        return await _productService.GetProductByIdAsync(Id);
    }
    [HttpGet("Name")]
    public async Task<ProductResponse> GetByEmail(string Name){
        return await _productService.GetProductByNameAsync(Name);
    }
    [HttpPost]
    public async Task<ProductResponse> CreateProduct([FromBody] CreateProductCommand createProductCommand){
        return await _productService.CreateProductAsync(createProductCommand);
    }
    [HttpPut]
    public async Task<ProductResponse> UpdateProduct([FromBody] UpdateProductCommand  updateProductCommand){
        return await _productService.UpdateProductAsync(updateProductCommand);
    }
}
