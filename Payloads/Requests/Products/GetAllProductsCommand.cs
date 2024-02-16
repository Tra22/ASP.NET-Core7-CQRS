using CQRS.Payloads.Responses.Products;
using MediatR;

namespace CQRS.Payloads.Requests.Products
{
    public class GetAllProductsCommand : IRequest<List<ProductResponse>>
    {
    }
}