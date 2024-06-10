FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TubeManager.Infrastructure.Migrations/TubeManager.Infrastructure.Migrations.csproj", "TubeManager.Infrastructure.Migrations/"]
RUN dotnet restore "TubeManager.Infrastructure.Migrations/TubeManager.Infrastructure.Migrations.csproj"
COPY . .
WORKDIR "/src/TubeManager.Infrastructure.Migrations"
RUN dotnet build "TubeManager.Infrastructure.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "TubeManager.Infrastructure.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TubeManager.Infrastructure.Migrations.dll"]
