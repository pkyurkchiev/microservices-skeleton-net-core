FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 5102

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS buildtime-base
WORKDIR /src

COPY BuildingBlocks/*/*/*.csproj /csproj-files/
COPY Services/*/*/*.csproj /csproj-files/
# TODO: Further improve for cache - restore packages here

FROM buildtime-base AS publish
COPY . .
WORKDIR /src/Services/Locations/Locations.API
RUN dotnet publish -c Release -o /app

FROM base AS final

WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Locations.API.dll"]
