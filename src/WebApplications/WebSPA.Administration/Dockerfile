FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
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

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
# Setup NodeJs
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
#RUN	npm install -g @angular/cli
# End setup
WORKDIR /src
COPY *.sln ./
COPY ["WebApplications/WebSPA.Administration/WebSPA.Administration.csproj", "WebApplications/WebSPA.Administration/"]
RUN dotnet restore "WebApplications/WebSPA.Administration/WebSPA.Administration.csproj" -nowarn:msb3202,nu1503
#COPY ["WebApplications/WebSPA.Administration/ClientApp/package.json", "WebApplications/WebSPA.Administration/ClientApp/"]
#
#RUN cd WebApplications/WebSPA.Administration/ClientApp \
    #&& npm i --silent
	
COPY . .
WORKDIR "/src/WebApplications/WebSPA.Administration"
RUN dotnet build "WebSPA.Administration.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebSPA.Administration.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebSPA.Administration.dll"]