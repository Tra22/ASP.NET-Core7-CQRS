using CQRS.Payloads.Requests.Products;
using CQRS.Payloads.Responses.Products;
using MediatR;

namespace CQRS.Services.Products{
    public class ProductService : IProductService
    {
        protected readonly IMediator _mediator;
        public ProductService(IMediator mediator){
            _mediator = mediator;
        }

        public async Task<ProductResponse> CreateProductAsync(CreateProductCommand createProductCommand)
        {
            return await _mediator.Send(createProductCommand);
        }

        public async Task<List<ProductResponse>> GetAllProductsAsync()
        {
            return await _mediator.Send(new GetAllProductsCommand());
        }

        public async Task<ProductResponse> GetProductByIdAsync(int Id)
        {
             return await _mediator.Send(new GetProductByIdCommand(Id));
        }

        public async Task<ProductResponse> GetProductByNameAsync(string Name)
        {
            return await _mediator.Send(new GetProductByNameCommand(Name));
        }

        public async Task<ProductResponse> UpdateProductAsync(UpdateProductCommand updateProductCommand)
        {
            return await _mediator.Send(updateProductCommand);
        }
    }
}