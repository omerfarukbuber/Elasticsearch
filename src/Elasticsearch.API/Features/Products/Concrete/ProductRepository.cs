using Elastic.Clients.Elasticsearch;
using Elasticsearch.API.Extensions;
using Elasticsearch.API.Features.Products.Abstract;

namespace Elasticsearch.API.Features.Products.Concrete;

public class ProductRepository(ElasticsearchClient client, DateTimeProvider dateTimeProvider) : IProductRepository
{
    private const string IndexName = "products";
    public async Task<Product?> SaveAsync(Product entity)
    {
        entity.Created = dateTimeProvider.UtcNow;

        var response = await client.IndexAsync(entity, x => x.Index(IndexName));

        if (!response.IsValidResponse) return null;

        entity.Id = response.Id;
        return entity;
    }
}