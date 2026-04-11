FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CustomerProfile.WebAPI/CustomerProfile.WebAPI.csproj", "CustomerProfile.WebAPI/"]
COPY ["CarRental.Gateway/CarRental.Gateway.csproj", "CarRental.Gateway/"]
COPY ["WebApiMiddleware/WebApiMiddleware.csproj", "WebApiMiddleware/"]
RUN dotnet restore "CustomerProfile.WebAPI/CustomerProfile.WebAPI.csproj"
COPY . .
WORKDIR "/src/CustomerProfile.WebAPI"
RUN dotnet build "./CustomerProfile.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CustomerProfile.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerProfile.WebAPI.dll"]
