using CQRS.Commands;
using CQRS.Commands.Products;
using CQRS.Data;
using CQRS.Handlers.Products;
using CQRS.Queries;
using CQRS.Queries.Products;
using CQRS.Services.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>
    (options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<DapperContext>(); 

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssemblies(
            typeof(GetAllProductsHandler).Assembly,
            typeof(GetProductByIdHandler).Assembly,
            typeof(GetProductByNameHandler).Assembly,
            typeof(CreateProductHandler).Assembly, 
            typeof(UpdateProductHandler).Assembly
        )
    );
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddTransient<IProductQueryRepository, ProductQueryRepository>();
builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddTransient<IProductCommandRepository, ProductCommandRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
