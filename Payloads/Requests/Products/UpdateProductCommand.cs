using CQRS.Payloads.Responses.Products;
using MediatR;

namespace CQRS.Payloads.Requests.Products
{
    public class UpdateProductCommand : IRequest<ProductResponse>
    {
        public int Id {get;set;}
        public string? Name {get;set;}
        public bool IsDeleted {get;set;} = true;
    }
}