#Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./KW.GeolocationService.Api/KW.GeolocationService.Api.csproj" --disable-parallel
RUN dotnet publish "./KW.GeolocationService.Api/KW.GeolocationService.Api.csproj" -c release -o /app --no-restore

#Serve stage
FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 9003

ENTRYPOINT ["dotnet", "KW.GeolocationService.Api.dll"]

#docker run --rm -p 9003:9003 -e ASPNETCORE_HTTP_PORT=https://+:9003 -e ASPNETCORE_URLS=http://+:9003 geoapi