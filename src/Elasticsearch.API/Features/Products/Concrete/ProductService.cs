using Elasticsearch.API.Features.Products.Abstract;

namespace Elasticsearch.API.Features.Products.Concrete;

public class ProductService(IProductRepository repository) : IProductService
{
    public async Task<ProductResponse?> CreateAsync(CreateProductRequest request)
    {
        var product = request.ToProduct();
        var response = await repository.SaveAsync(product);
        return response is null
            ? null
            : ProductResponse.FromProduct(response);
    }
}