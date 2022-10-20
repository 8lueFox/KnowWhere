using System.Text.Json.Serialization;

namespace KW.GeolocationService.Application.Requests;

public class GeocodingDto
{
    [JsonPropertyName("hits")]
    public Hit[] Hits { get; set; }

    public int Took { get; set; }
}

public class Hit
{
    [JsonPropertyName("point")]
    public Point Point { get; set; }

    [JsonPropertyName("osm_id")]
    public string OsmId { get; set; }

    [JsonPropertyName("osm_type")]
    public string OsmType { get; set; } //N = node, R = relation, W = way

    [JsonPropertyName("osm_key")]
    public string OsmKey { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("street")]
    public string Street { get; set; }

    [JsonPropertyName("housenumber")]
    public string HouseNumber { get; set; }

    [JsonPropertyName("postcode")]
    public string PostCode { get; set; }
}

public class Point
{
    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lng")]
    public double Lng { get; set; }
}