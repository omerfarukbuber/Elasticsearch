namespace Elasticsearch.API.Features.Products;

public sealed record UpdateProductRequest(
    string Id,
    string Name,
    decimal Price,
    int Stock,
    ProductFeatureRequest ProductFeature)
{
    public Product ToProduct()
    {
        return new Product()
        {
            Id = Id,
            Name = Name,
            Price = Price,
            Stock = Stock,
            ProductFeature = new ProductFeature()
            {
                Width = ProductFeature.Width,
                Height = ProductFeature.Height,
                Color = ProductFeature.Color
            }
        };
    }
};