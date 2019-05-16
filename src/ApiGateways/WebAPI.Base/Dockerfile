FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ApiGateways/WebAPI.Base/WebAPI.Base.csproj ApiGateways/WebAPI.Base/
RUN dotnet restore ApiGateways/WebAPI.Base/WebAPI.Base.csproj
COPY . .
WORKDIR /src/ApiGateways/WebAPI.Base
RUN dotnet build WebAPI.Base.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WebAPI.Base.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAPI.Base.dll"]
