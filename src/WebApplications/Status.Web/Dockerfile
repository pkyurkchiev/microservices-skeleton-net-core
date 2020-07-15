FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS buildtime-base
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "src/SkeletonOnContainers.sln" "src/SkeletonOnContainers.sln"

COPY "src/BuildingBlocks/EventMQ/EventBus/EventBus.csproj" "src/BuildingBlocks/EventMQ/EventBus/EventBus.csproj"
COPY "src/BuildingBlocks/EventMQ/EventBusRabbitMQ/EventBus.RabbitMQ.csproj" "src/BuildingBlocks/EventMQ/EventBusRabbitMQ/EventBus.RabbitMQ.csproj"
COPY "src/BuildingBlocks/WebHost/WebHost.Customization/WebHost.Customization.csproj" "src/BuildingBlocks/WebHost/WebHost.Customization/WebHost.Customization.csproj"

COPY "src/Services/Identity/Identity.API/Identity.API.csproj" "src/Services/Identity/Identity.API/Identity.API.csproj"

COPY "src/Services/KnowledgeBase/KnowledgeBase.API/KnowledgeBase.API.csproj" "src/Services/KnowledgeBase/KnowledgeBase.API/KnowledgeBase.API.csproj"
COPY "src/Services/KnowledgeBase/KnowledgeBase.Data/KnowledgeBase.Data.csproj" "src/Services/KnowledgeBase/KnowledgeBase.Data/KnowledgeBase.Data.csproj"
COPY "src/Services/KnowledgeBase/KnowledgeBase.Infrastructure/KnowledgeBase.Infrastructure.csproj" "src/Services/KnowledgeBase/KnowledgeBase.Infrastructure/KnowledgeBase.Infrastructure.csproj"

COPY "src/Services/Locations/Locations.API/Locations.API.csproj" "src/Services/Locations/Locations.API/Locations.API.csproj"
COPY "src/Services/Locations/Locations.Data/Locations.Data.csproj" "src/Services/Locations/Locations.Data/Locations.Data.csproj"
COPY "src/Services/Locations/Locations.Infrastructure/Locations.Infrastructure.csproj" "src/Services/Locations/Locations.Infrastructure/Locations.Infrastructure.csproj"

COPY "src/WebApplications/Status.Web/Status.Web.csproj" "src/WebApplications/Status.Web/Status.Web.csproj"
COPY "src/WebApplications/WebSPA.Administration/WebSPA.Administration.csproj" "src/WebApplications/WebSPA.Administration/WebSPA.Administration.csproj"
COPY "src/WebApplications/WebSPA.KnowledgeBase/WebSPA.KnowledgeBase.csproj" "src/WebApplications/WebSPA.KnowledgeBase/WebSPA.KnowledgeBase.csproj"

COPY "docker-compose.dcproj" "docker-compose.dcproj"

COPY "NuGet.config" "NuGet.config"

RUN dotnet restore "src/SkeletonOnContainers.sln"

COPY . .
WORKDIR /src/src/WebApplications/Status.Web
RUN dotnet publish -c Release -o /app

FROM buildtime-base AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Status.Web.dll"]
