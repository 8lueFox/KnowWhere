using KW.GeolocationService.Application.Requests;

namespace KW.GeolocationService.Application;

public interface IHooperService
{
    Task<RouteDto> GetRoute(GetRouteRequest request);

    Task<GeocodingDto> GetGeocoding(GetGeocode request);
}