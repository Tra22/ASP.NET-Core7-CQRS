using CQRS.Entities;
using CQRS.Mappers.Products;
using CQRS.Payloads.Requests.Products;
using CQRS.Payloads.Responses.Products;
using CQRS.Queries.Products;
using MediatR;

namespace CQRS.Handlers.Products
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsCommand, List<ProductResponse>>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        public GetAllProductsHandler(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }
        public async Task<List<ProductResponse>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            List<Product> products = (List<Product>)await _productQueryRepository.GetAllAsync();
            var productResponses = ProductMapper.Mapper.Map<List<Product>, List<ProductResponse>>(products);
            return productResponses;
        }
    }
}
