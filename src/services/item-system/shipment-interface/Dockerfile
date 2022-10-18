FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["shipment-interface.csproj", "."]
RUN dotnet restore "./shipment-interface.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "shipment-interface.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "shipment-interface.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "shipment-interface.dll"]