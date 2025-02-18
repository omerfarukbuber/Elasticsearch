namespace Elasticsearch.API.Features.Products.Abstract;

public interface IProductService
{
    Task<ProductResponse?> CreateAsync(CreateProductRequest request);
}