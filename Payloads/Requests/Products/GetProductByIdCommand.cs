using CQRS.Payloads.Responses.Products;
using MediatR;

namespace CQRS.Payloads.Requests.Products{
    public class GetProductByIdCommand : IRequest<ProductResponse>{
        public int Id { get;set; }
        public GetProductByIdCommand(int Id){
            this.Id = Id;
        }
    }
}