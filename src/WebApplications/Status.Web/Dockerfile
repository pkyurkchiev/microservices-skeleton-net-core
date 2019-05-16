FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY *.sln ./
COPY WebApplications/Status.Web/Status.Web.csproj WebApplications/Status.Web/
RUN dotnet restore
COPY . .
WORKDIR /src/WebApplications/Status.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Status.Web.dll"]
