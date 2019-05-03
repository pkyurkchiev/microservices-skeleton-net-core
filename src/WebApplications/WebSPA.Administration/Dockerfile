FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
# Setup NodeJs
RUN apt-get update -qq && \
    apt-get install -qq -y wget && \
    apt-get install -qq -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_10.x | bash - && \
    apt-get install -qq -y build-essential nodejs && \
    apt-get install -qq -y nginx
# End setup
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
# Setup NodeJs
RUN apt-get update -qq && \
    apt-get install -qq -y wget && \
    apt-get install -qq -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_8.x | bash - && \
    apt-get install -qq -y build-essential nodejs && \
    apt-get install -qq -y nginx
# End setup
WORKDIR /src
COPY *.sln ./
COPY ["WebApplications/WebSPA.Administration/WebSPA.Administration.csproj", "WebApplications/WebSPA.Administration/"]
RUN dotnet restore "WebApplications/WebSPA.Administration/WebSPA.Administration.csproj" -nowarn:msb3202,nu1503
COPY ["WebApplications/WebSPA.Administration/ClientApp/package.json", "WebApplications/WebSPA.Administration/ClientApp/"]

RUN cd WebApplications/WebSPA.Administration/ClientApp \
    && npm i --silent
	
COPY . .
WORKDIR "/src/WebApplications/WebSPA.Administration"

RUN dotnet build "WebSPA.Administration.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebSPA.Administration.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebSPA.Administration.dll"]