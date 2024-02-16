using CQRS.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)  { }
        public DbSet<Product>  Products { get; set; }

    }
}