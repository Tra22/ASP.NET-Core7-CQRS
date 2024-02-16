using CQRS.Data;
using CQRS.Entities;

namespace CQRS.Commands.Products{
    public class ProductCommandRepository : CommandRepository<Product>, IProductCommandRepository
    {
        public ProductCommandRepository(DataContext context) : base(context)
        {
        }
    }
}