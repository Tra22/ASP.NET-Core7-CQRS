using CQRS.Commands.Products;
using CQRS.Entities;
using CQRS.Mappers.Products;
using CQRS.Payloads.Requests.Products;
using CQRS.Payloads.Responses.Products;
using MediatR;

namespace CQRS.Handlers.Products
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        public UpdateProductHandler(IProductCommandRepository productCommandRepository)
        {
            _productCommandRepository = productCommandRepository;
        }
        public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var produtctEntity = ProductMapper.Mapper.Map<Product>(request);

            if(produtctEntity is null)
            {
                throw new ApplicationException("There is a problem in mapper");
            }

            await _productCommandRepository.UpdateAsync(produtctEntity);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(produtctEntity);
            return productResponse;
        }
    }
}
