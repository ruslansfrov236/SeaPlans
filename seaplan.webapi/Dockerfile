# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["seaplan.webapi/seaplan.webapi.csproj", "seaplan.webapi/"]
COPY ["seaplan.business/seaplan.business.csproj", "seaplan.business/"]
COPY ["seaplan.data/seaplan.data.csproj", "seaplan.data/"]
COPY ["seaplan.entity/seaplan.entity.csproj", "seaplan.entity/"]

COPY  ../seaplan.webapi/wwwroot /app/wwwroot

# Restore the project dependencies
RUN dotnet restore "seaplan.webapi/seaplan.webapi.csproj"
COPY . .
WORKDIR "/src/seaplan.webapi"
RUN dotnet build "seaplan.webapi.csproj" -c Release -o /app/build

# Publish the build
FROM build AS publish
RUN dotnet publish "seaplan.webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "seaplan.webapi.dll"]
