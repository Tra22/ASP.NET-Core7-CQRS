using CQRS.Payloads.Responses.Products;
using MediatR;

namespace CQRS.Payloads.Requests.Products{
    public class GetProductByNameCommand : IRequest<ProductResponse> {

        public string? Name {get;set;}
        public GetProductByNameCommand(string Name)
        {
            this.Name = Name;
        }
    }
}