FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS  buildtime-base
WORKDIR /src

COPY src/BuildingBlocks/*/*/*.csproj /src/csproj-files/
COPY src/Services/*/*/*.csproj /src/csproj-files/
# TODO: Further improve for cache - restore packages here

FROM buildtime-base AS publish
COPY . .
WORKDIR /src/src/Services/Identity/Identity.API
RUN dotnet publish -c Release -o /app

FROM base AS final

WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Identity.API.dll"]
