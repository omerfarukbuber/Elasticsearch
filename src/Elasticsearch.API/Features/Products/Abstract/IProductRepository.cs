namespace Elasticsearch.API.Features.Products.Abstract;

public interface IProductRepository
{
    Task<IReadOnlyCollection<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(string id);
    Task<Product?> SaveAsync(Product entity);
    Task<bool> UpdateAsync(Product entity);
    Task<bool> DeleteAsync(string id);
}