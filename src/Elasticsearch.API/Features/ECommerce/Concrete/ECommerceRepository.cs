using Elastic.Clients.Elasticsearch;
using Elasticsearch.API.Features.ECommerce.Abstract;
using System.Collections.Immutable;

namespace Elasticsearch.API.Features.ECommerce.Concrete;

public class ECommerceRepository(ElasticsearchClient client) : IECommerceRepository
{
    private const string IndexName = "kibana_sample_data_ecommerce";
    private const string CustomerFirstNameField = "customer_first_name.keyword";
    public async Task<ImmutableList<ECommerce>> TermSearchByCustomerFirstNameAsync(string customerFirstName)
    {
        var response = await client.SearchAsync<ECommerce>(s =>
            s.Index(IndexName)
                .Query(q => 
                    q.Term(term => 
                        term.Field(CustomerFirstNameField!).Value(customerFirstName))));

        if (!response.IsValidResponse)
            return ImmutableList<ECommerce>.Empty;

        foreach (var hit in response.Hits) hit.Source!.Id = hit.Id!;

        return response.Documents.ToImmutableList();
    }
}