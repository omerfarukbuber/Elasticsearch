using System.Collections.Immutable;

namespace Elasticsearch.API.Features.ECommerce.Abstract;

public interface IECommerceRepository
{
    Task<ImmutableList<ECommerce>> TermSearchByCustomerFirstNameAsync(string customerFirstName);
    Task<ImmutableList<ECommerce>> TermsSearchByCustomerFirstNamesAsync(List<string> customerFirstNames);
}