using CQRS.Commands.Products;
using CQRS.Entities;
using CQRS.Mappers.Products;
using CQRS.Payloads.Requests.Products;
using CQRS.Payloads.Responses.Products;
using MediatR;

namespace CQRS.Handlers.Products
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        public CreateProductHandler(IProductCommandRepository productCommandRepository)
        {
            _productCommandRepository = productCommandRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var produtctEntity = ProductMapper.Mapper.Map<Product>(request);

            if(produtctEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            var newProduct = await _productCommandRepository.AddAsync(produtctEntity);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(newProduct);
            return productResponse;
        }
    }
}
