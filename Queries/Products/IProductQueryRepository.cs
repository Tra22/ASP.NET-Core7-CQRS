using CQRS.Entities;

namespace CQRS.Queries.Products {
    public interface IProductQueryRepository {
        Task<IReadOnlyList<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int Id);
        Task<Product?> GetProductByNameAsync(string Name);
    }
}