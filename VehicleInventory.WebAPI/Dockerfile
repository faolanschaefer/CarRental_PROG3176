FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["VehicleInventory.WebAPI/VehicleInventory.WebAPI.csproj", "VehicleInventory.WebAPI/"]
COPY ["CarRental.Gateway/CarRental.Gateway.csproj", "CarRental.Gateway/"]
COPY ["WebApiMiddleware/WebApiMiddleware.csproj", "WebApiMiddleware/"]
COPY ["VehicleInventory.Application/VehicleInventory.Application.csproj", "VehicleInventory.Application/"]
COPY ["VehicleInventory.Domain/VehicleInventory.Domain.csproj", "VehicleInventory.Domain/"]
COPY ["VehicleInventory.Infrastructure/VehicleInventory.Infrastructure.csproj", "VehicleInventory.Infrastructure/"]
RUN dotnet restore "VehicleInventory.WebAPI/VehicleInventory.WebAPI.csproj"
COPY . .
WORKDIR "/src/VehicleInventory.WebAPI"
RUN dotnet build "./VehicleInventory.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VehicleInventory.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehicleInventory.WebAPI.dll"]
