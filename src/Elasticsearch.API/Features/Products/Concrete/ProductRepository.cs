using System.Collections.ObjectModel;
using Elastic.Clients.Elasticsearch;
using Elasticsearch.API.Extensions;
using Elasticsearch.API.Features.Products.Abstract;

namespace Elasticsearch.API.Features.Products.Concrete;

public class ProductRepository(ElasticsearchClient client, DateTimeProvider dateTimeProvider) : IProductRepository
{
    private const string IndexName = "products";
    public async Task<IReadOnlyCollection<Product>> GetAllAsync()
    {
        var response = await client.SearchAsync<Product>(s => s.Index(IndexName)
            .Query(q => q.MatchAll(_ => {})));
        if (!response.IsValidResponse)
            return ReadOnlyCollection<Product>.Empty;

        foreach (var hit in response.Hits) hit.Source!.Id = hit.Id!;

        return response.Documents;
    }

    public async Task<Product?> GetByIdAsync(string id)
    {
        var response = await client.GetAsync<Product>(IndexName,id);
        if (response.Source != null) response.Source.Id = response.Id;
        return response.Source;
    }

    public async Task<Product?> SaveAsync(Product entity)
    {
        entity.Created = dateTimeProvider.UtcNow;

        var response = await client.IndexAsync(entity, x => x.Index(IndexName));

        if (!response.IsValidResponse) return null;

        entity.Id = response.Id;
        return entity;
    }

    public async Task<bool> UpdateAsync(Product entity)
    {
        entity.Updated = dateTimeProvider.UtcNow;
        var response = await client.UpdateAsync<Product, object>(IndexName, entity.Id,
            u =>u.Doc(new
            {
                entity.Name,
                entity.Price,
                entity.Stock,
                entity.Created,
                entity.Updated,
                entity.ProductFeature
            }));
        return response.IsValidResponse;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var response = await client.DeleteAsync<Product>(IndexName, id);
        return response.IsValidResponse;
    }
}