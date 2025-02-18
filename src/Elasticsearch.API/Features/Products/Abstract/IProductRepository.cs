namespace Elasticsearch.API.Features.Products.Abstract;

public interface IProductRepository
{
    Task<Product?> SaveAsync(Product entity);
}