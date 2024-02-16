using CQRS.Payloads.Requests.Products;
using CQRS.Payloads.Responses.Products;

namespace CQRS.Services.Products{
    public interface IProductService {
        Task<List<ProductResponse>> GetAllProductsAsync();
        Task<ProductResponse> GetProductByIdAsync(int Id);
        Task<ProductResponse> GetProductByNameAsync(string Name);
        Task<ProductResponse> CreateProductAsync(CreateProductCommand createProductCommand);
        Task<ProductResponse> UpdateProductAsync(UpdateProductCommand updateProductCommand);
    }
}