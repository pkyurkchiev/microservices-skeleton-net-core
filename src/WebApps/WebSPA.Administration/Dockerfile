FROM microsoft/aspnetcore:2.0 AS base
# BEGIN MODIFICATION - Node is needed for development (but not production)
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
    apt-get install -y build-essential nodejs
# END MODIFICATION
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY WebApps/WebSPA.Administration/WebSPA.Administration.csproj WebApps/WebSPA.Administration/
RUN dotnet restore
COPY . .
WORKDIR /src/WebApps/WebSPA.Administration
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebSPA.Administration.dll"]
