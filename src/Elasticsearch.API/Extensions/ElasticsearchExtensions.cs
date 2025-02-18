using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace Elasticsearch.API.Extensions;

internal static class ElasticsearchExtensions
{
    internal static IServiceCollection AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
    {
        var elasticOptions = configuration.GetSection("Elasticsearch").Get<ElasticsearchOptions>();
        var elasticSettings = new ElasticsearchClientSettings(new Uri(elasticOptions!.Uri))
            .Authentication(new BasicAuthentication(elasticOptions.Username, elasticOptions.Password));
        services.AddSingleton(sp => new ElasticsearchClient(elasticSettings));
        return services;
    }
}