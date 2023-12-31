FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
# COPY WebAPI/aspnetapp.pfx aspnetapp.pfx

# RUN apt-get update -qq && apt-get -y install libgdiplus libc6-dev

# ENV ASPNETCORE_URLS=https://+:443;http://+:80

ENV ASPNETCORE_URLS=http://+:80

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Dev
WORKDIR /src
COPY ["ApplicationLayer/ApplicationLayer.csproj", "ApplicationLayer/"]
COPY ["DomainLayer/DomainLayer.csproj", "DomainLayer/"]
COPY ["InfrastructureLayer/InfrastructureLayer.csproj", "InfrastructureLayer/"]
COPY ["PresentationLayer/PresentationLayer.csproj", "PresentationLayer/"]
COPY ["WebAPI/WebAPI.csproj", "WebAPI/"]
RUN dotnet restore "WebAPI/WebAPI.csproj"
COPY . .
WORKDIR "/src/WebAPI"
RUN dotnet build "WebAPI.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "WebAPI.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]