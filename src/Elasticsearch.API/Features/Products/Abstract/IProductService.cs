namespace Elasticsearch.API.Features.Products.Abstract;

public interface IProductService
{
    Task<IList<ProductResponse>> GetAllAsync();
    Task<ProductResponse?> GetByIdAsync(string id);
    Task<ProductResponse?> CreateAsync(CreateProductRequest request);
    Task<bool> UpdateAsync(UpdateProductRequest request);
    Task<bool> DeleteAsync(string id);
}