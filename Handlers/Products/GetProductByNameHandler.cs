using CQRS.Commands.Products;
using CQRS.Entities;
using CQRS.Mappers.Products;
using CQRS.Payloads.Requests.Products;
using CQRS.Payloads.Responses.Products;
using CQRS.Queries.Products;
using MediatR;

namespace CQRS.Handlers.Products
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameCommand, ProductResponse>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        public GetProductByNameHandler(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }
        public async Task<ProductResponse> Handle(GetProductByNameCommand request, CancellationToken cancellationToken)
        {
            Product? productEntity = await _productQueryRepository.GetProductByNameAsync(request.Name??"");
            var productResponse = ProductMapper.Mapper.Map<ProductResponse>(productEntity);
            return productResponse;
        }
    }
}
