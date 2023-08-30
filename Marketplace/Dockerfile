# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./Marketplace.Api/Marketplace.Api.csproj" --disable-parallel
RUN dotnet publish "./Marketplace.Api/Marketplace.Api.csproj" -c release -o /app --no-restore

# Server Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "Marketplace.Api.dll" ]
