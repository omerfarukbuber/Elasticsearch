using Elasticsearch.API.Extensions;
using Elasticsearch.API.Features.ECommerce.Abstract;
using Elasticsearch.API.Features.ECommerce.Concrete;
using Elasticsearch.API.Features.Products.Abstract;
using Elasticsearch.API.Features.Products.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddElasticsearch(builder.Configuration);

builder.Services.AddTransient(sp => new DateTimeProvider());
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IECommerceRepository, ECommerceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });
    await app.SeedDataAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
