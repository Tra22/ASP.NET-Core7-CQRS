namespace CQRS.Payloads.Responses.Products {
    public class ProductResponse {
        public int Id {get;set;}
        public string? Name {get;set;}
        public bool IsDeleted {get;set;} = true;
    } 
}