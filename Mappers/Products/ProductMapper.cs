using AutoMapper;

namespace CQRS.Mappers.Products
{
    public class ProductMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(()=>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.ShouldMapProperty = p => p.GetMethod != null && (p.GetMethod.IsPublic || p.GetMethod.IsAssembly);
                cfg.AddProfile<ProductMappingProfile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}