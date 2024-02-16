using CQRS.Commands.Products;
using CQRS.Entities;
using CQRS.Mappers.Products;
using CQRS.Payloads.Requests.Products;
using CQRS.Payloads.Responses.Products;
using CQRS.Queries.Products;
using MediatR;

namespace CQRS.Handlers.Products
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdCommand, ProductResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        public GetProductByIdHandler(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }
        public async Task<ProductResponse> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            Product? productEntity = await _productQueryRepository.GetByIdAsync(request.Id);
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(productEntity);
            return productResponse;
        }
    }
}
