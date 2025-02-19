﻿using System.Text.Json.Serialization;

namespace Elasticsearch.API.Features.ECommerce;

public sealed class ECommerce
{
    [JsonPropertyName("_id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("customer_first_name")]
    public string CustomerFirstName { get; set; } = null!;

    [JsonPropertyName("customer_last_name")]
    public string CustomerLastName { get; set; } = null!;

    [JsonPropertyName("customer_full_name")]
    public string CustomerFullName { get; set; } = null!;

    [JsonPropertyName("category")] 
    public string[] Category { get; set; } = [];

    [JsonPropertyName("order_date")]
    public DateTime OrderDate { get; set; }

    [JsonPropertyName("products")]
    public ECommerceProduct[] Products { get; set; } = [];

}