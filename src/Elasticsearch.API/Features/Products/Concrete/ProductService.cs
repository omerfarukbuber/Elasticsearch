using Elasticsearch.API.Features.Products.Abstract;

namespace Elasticsearch.API.Features.Products.Concrete;

public class ProductService(IProductRepository repository) : IProductService
{
    public async Task<IList<ProductResponse>> GetAllAsync()
    {
        var response = await repository.GetAllAsync();
        return response.Select(ProductResponse.FromProduct).ToList();
    }

    public async Task<ProductResponse?> GetByIdAsync(string id)
    {
        var response = await repository.GetByIdAsync(id);
        return response is null
            ? null
            : ProductResponse.FromProduct(response);
    }

    public async Task<ProductResponse?> CreateAsync(CreateProductRequest request)
    {
        var product = request.ToProduct();
        var response = await repository.SaveAsync(product);
        return response is null
            ? null
            : ProductResponse.FromProduct(response);
    }

    public async Task<bool> UpdateAsync(UpdateProductRequest request)
    {
        var existingProduct = await repository.GetByIdAsync(request.Id);
        if (existingProduct is null) return false;

        var product = request.ToProduct();
        product.Created = existingProduct.Created;

        return await repository.UpdateAsync(product);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await repository.DeleteAsync(id);
    }
}