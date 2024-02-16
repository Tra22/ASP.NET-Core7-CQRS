using CQRS.Entities;

namespace CQRS.Commands.Products{
    public interface IProductCommandRepository : ICommandRepository<Product> {
        
    }
}