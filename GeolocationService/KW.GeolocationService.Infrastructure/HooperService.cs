using KW.GeolocationService.Application;
using KW.GeolocationService.Application.Requests;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KW.GeolocationService.Infrastructure;

public class HooperService : IHooperService
{
    private readonly HooperSettings _settings;

    public HooperService(IOptions<HooperSettings> settings)
    {
        _settings = settings.Value;
    }

    public async Task<RouteDto> GetRoute(GetRouteRequest request)
    {
        //https://graphhopper.com/api/1/route?point=54.5963868,-7.2986718&point=54.985647,-7.3247798&vehicle=car&debug=true&type=json&points_encoded=false&key=179c81af-d8d4-4a31-86f8-9e158df86b4a

        var url = "https://graphhopper.com/api/1/route?"
            + $"point={request.StartPointX.ToString().Replace(',', '.')},{request.StartPointY.ToString().Replace(',', '.')}&"
            + $"point={request.EndPointX.ToString().Replace(',', '.')},{request.EndPointY.ToString().Replace(',', '.')}&"
            + $"vehicle={request.Vehicle}&"
            + $"debug={request.Debug}&"
            + $"type=json&points_encoded=false&key={_settings.Key}";

        using var client = new HttpClient();
        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var contentString = await response.Content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<RouteDto>(contentString);
        return obj;
    }

    public async Task<GeocodingDto> GetGeocoding(GetGeocode request)
    {
        //https://graphhopper.com/api/1/geocode?q=LondonDerry Victoria Road

        var url = "https://graphhopper.com/api/1/geocode?"
            + $"q={request.Query}"
            + $"&key={_settings.Key}";

        Console.WriteLine(url);

        using var client = new HttpClient();
        var response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var contentString = await response.Content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<GeocodingDto>(contentString);
        return obj;
    }
}


//{
//  "startPointX": 54.5963868,
//  "startPointY": -7.2986718,
//  "endPointX": 54.985647,
//  "endPointY": -7.3247798,
//  "vehicle": "car",
//  "debug": "debug"
//}