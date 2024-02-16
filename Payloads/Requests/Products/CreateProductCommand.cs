using CQRS.Payloads.Responses.Products;
using MediatR;

namespace CQRS.Payloads.Requests.Products
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        public string? Name {get;set;}
        public bool IsDeleted {get;set;} = true;
    }
}