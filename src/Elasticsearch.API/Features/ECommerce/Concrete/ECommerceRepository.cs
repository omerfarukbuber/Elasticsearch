using Elastic.Clients.Elasticsearch;
using Elasticsearch.API.Features.ECommerce.Abstract;
using System.Collections.Immutable;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Elasticsearch.API.Features.ECommerce.Concrete;

public class ECommerceRepository(ElasticsearchClient client) : IECommerceRepository
{
    private const string IndexName = "kibana_sample_data_ecommerce";
    private const string CustomerFirstNameField = "customer_first_name.keyword";
    private const string KeywordSuffix = "keyword";
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

    public async Task<ImmutableList<ECommerce>> TermsSearchByCustomerFirstNamesAsync(List<string> customerFirstNames)
    {
        List<FieldValue> fieldValues = [];
        customerFirstNames.ForEach(c => fieldValues.Add(c));

        var response = await client.SearchAsync<ECommerce>(s =>
            s.Index(IndexName)
                .Query(q => 
                    q.Terms(terms => terms.Field(field => field.CustomerFirstName.Suffix(KeywordSuffix))
                        .Terms(new TermsQueryField(fieldValues)))));

        if (!response.IsValidResponse)
            return ImmutableList<ECommerce>.Empty;

        foreach (var hit in response.Hits) hit.Source!.Id = hit.Id!;

        return response.Documents.ToImmutableList();
    }
}