FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
# Setup NodeJs
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
#RUN	npm install -g @angular/cli
# End setup
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
# Setup NodeJs
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
#RUN	npm install -g @angular/cli
# End setup
WORKDIR /src
COPY ["src/WebApplications/WebSPA.KnowledgeBase/WebSPA.KnowledgeBase.csproj", "src/WebApplications/WebSPA.KnowledgeBase/"]
RUN dotnet restore "src/WebApplications/WebSPA.KnowledgeBase/WebSPA.KnowledgeBase.csproj" -nowarn:msb3202,nu1503
	
COPY . .
WORKDIR "/src/src/WebApplications/WebSPA.KnowledgeBase"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebSPA.KnowledgeBase.dll"]