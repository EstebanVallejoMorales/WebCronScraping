#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RockwellAutomation.Challenge.WebCronScrapping.csproj", "."]
RUN dotnet restore "./././RockwellAutomation.Challenge.WebCronScrapping.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./RockwellAutomation.Challenge.WebCronScrapping.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RockwellAutomation.Challenge.WebCronScrapping.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

RUN apt-get update && apt-get install -y chromium
ENV CHROME_BIN=/usr/bin/chromium

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RockwellAutomation.Challenge.WebCronScrapping.dll"]


