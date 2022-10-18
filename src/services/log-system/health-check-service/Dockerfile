FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["health-check-service.csproj", "."]
RUN dotnet restore "./health-check-service.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "health-check-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "health-check-service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "health-check-service.dll"]