using CQRS.Data;
using CQRS.Entities;
using Dapper;

namespace CQRS.Queries.Products{
    public class ProductQueryRepository : QueryRepository<Product>, IProductQueryRepository
    {
        public ProductQueryRepository(DapperContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var query = "SELECT * FROM \"Products\"";
            using (var connection = _context.CreateConnection())
            {
                var products = await connection.QueryAsync<Product>(query);
                return products.ToList();
            }
        }

        public async Task<Product?> GetByIdAsync(int Id)
        {
            var query = "SELECT * FROM \"Products\" WHERE \"Id\" = @Id";
            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id });
                return product;
            }
        }

        public async Task<Product?> GetProductByNameAsync(string Name)
        {
            var query = "SELECT * FROM \"Products\" WHERE \"Name\" = @Name";
            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QuerySingleOrDefaultAsync<Product>(query, new { Name });
                return product;
            }
        }
    }
}