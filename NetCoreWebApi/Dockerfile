#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["NetCoreWebApi/NetCoreWebApi.csproj", "NetCoreWebApi/"]
#RUN dotnet restore "NetCoreWebApi/NetCoreWebApi.csproj"
#COPY . .
#WORKDIR "/src/NetCoreWebApi"
#RUN dotnet build "NetCoreWebApi.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "NetCoreWebApi.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "NetCoreWebApi.dll"]

# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
EXPOSE 80
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY ../ ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "NetCoreWebApi.dll"]