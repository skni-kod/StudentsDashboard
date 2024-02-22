FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./API/StudentsDashboard.Api/StudentsDashboard.Api.csproj", "StudentsDashboard.Api/"]
RUN  dotnet restore "./StudentsDashboard.Api/./StudentsDashboard.Api.csproj"
COPY . .
WORKDIR "/src/API/StudentsDashboard.Api"
RUN dotnet build "./StudentsDashboard.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StudentsDashboard.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentsDashboard.Api.dll"]