namespace Elasticsearch.API.Features.Products;

public sealed record ProductResponse(
    string Id,
    string Name,
    decimal Price,
    int Stock,
    DateTime Created,
    DateTime? Updated,
    ProductFeatureResponse? ProductFeature)
{
    public static ProductResponse FromProduct(Product product)
    {
        return new ProductResponse(
            product.Id,
            product.Name,
            product.Price,
            product.Stock,
            product.Created, 
            product.Updated,
            product.ProductFeature != null
                ? new ProductFeatureResponse(product.ProductFeature.Width,
                    product.ProductFeature.Height,
                    product.ProductFeature.Color)
                : null
        );
    }
}