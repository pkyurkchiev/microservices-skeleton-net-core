FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY *.sln ./
COPY ["Services/KnowledgeBase/KnowledgeBase.API/KnowledgeBase.API.csproj", "Services/KnowledgeBase/KnowledgeBase.API/"]
RUN dotnet restore "Services/KnowledgeBase/KnowledgeBase.API/KnowledgeBase.API.csproj"
COPY . .
WORKDIR "/src/Services/KnowledgeBase/KnowledgeBase.API"
RUN dotnet build "KnowledgeBase.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KnowledgeBase.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "KnowledgeBase.API.dll"]