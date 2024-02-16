using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRS.Entities
{
     public class Product{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string? Name {get;set;}
        public bool IsDeleted {get;set;} = true;
    }
}