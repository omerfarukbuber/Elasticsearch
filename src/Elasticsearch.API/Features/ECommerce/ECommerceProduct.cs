using System.Text.Json.Serialization;

namespace Elasticsearch.API.Features.ECommerce;

public sealed class ECommerceProduct
{
    [JsonPropertyName("product_id")]
    public long ProductId { get; set; }

    [JsonPropertyName("product_name")] 
    public string ProductName { get; set; } = null!;
}