FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5284

ENV ASPNETCORE_URLS=http://+:5284

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["order-service-api/order-service-api.csproj", "order-service-api/"]
RUN dotnet restore "order-service-api/order-service-api.csproj"
COPY . .
WORKDIR "/src/order-service-api"
RUN dotnet build "order-service-api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "order-service-api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "order-service-api.dll"]
