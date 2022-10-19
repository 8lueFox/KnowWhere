namespace KW.GeolocationService.Application.Requests;

public record GetRouteRequest(double StartPointX, double StartPointY, double EndPointX, double EndPointY, string Vehicle = "car", string Debug = "true");