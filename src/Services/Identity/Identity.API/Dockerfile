FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY *.sln ./
COPY Services/Identity/Identity.API/Identity.API.csproj Services/Identity/Identity.API/
RUN dotnet restore
COPY . .
WORKDIR /src/Services/Identity/Identity.API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Identity.API.dll"]
