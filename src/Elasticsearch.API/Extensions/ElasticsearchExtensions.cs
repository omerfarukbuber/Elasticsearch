using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Elasticsearch.API.Features.Products;
using Elasticsearch.API.Features.Products.Abstract;

namespace Elasticsearch.API.Extensions;

internal static class ElasticsearchExtensions
{
    internal static IServiceCollection AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        var elasticOptions = configuration.GetSection("Elasticsearch").Get<ElasticsearchOptions>();
        var elasticSettings = new ElasticsearchClientSettings(new Uri(elasticOptions!.Uri))
            .Authentication(new BasicAuthentication(elasticOptions.Username, elasticOptions.Password));
        services.AddSingleton(_ => new ElasticsearchClient(elasticSettings));
        return services;
    }

    internal static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
    {
        var productService = app.ApplicationServices.GetRequiredService<IProductService>();

        var products = await productService.GetAllAsync();
        if (products.Count > 0) return app;

        var sampleProducts = new List<CreateProductRequest>
        {
            new CreateProductRequest("Laptop", 15000m, 10, new ProductFeatureRequest(35, 25, Colors.Blue)),
            new CreateProductRequest("Smartphone", 12000m, 25, new ProductFeatureRequest(7, 15, Colors.Red)),
            new CreateProductRequest("Monitor", 8000m, 15, new ProductFeatureRequest(50, 30, Colors.Green)),
            new CreateProductRequest("Keyboard", 1000m, 50, new ProductFeatureRequest(45, 15, Colors.Blue)),
            new CreateProductRequest("Mouse", 500m, 75, new ProductFeatureRequest(10, 5, Colors.Red)),
            new CreateProductRequest("Headphones", 2500m, 30, new ProductFeatureRequest(20, 20, Colors.Green)),
            new CreateProductRequest("Smartwatch", 5000m, 20, new ProductFeatureRequest(5, 5, Colors.Blue)),
            new CreateProductRequest("Tablet", 11000m, 18, new ProductFeatureRequest(25, 15, Colors.Red)),
            new CreateProductRequest("Printer", 6000m, 12, new ProductFeatureRequest(40, 25, Colors.Green)),
            new CreateProductRequest("Webcam", 2000m, 40, new ProductFeatureRequest(8, 5, Colors.Blue))
        };

        foreach (var product in sampleProducts)
        {
            await productService.CreateAsync(product);
        }
        

        return app;
    }
}