FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80


# Copy the requird project to same place
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY CatelogService.API/CatelogService.API.csproj CatelogService.API/
COPY CatelogService.Model/CatelogService.Model.csproj CatelogService.Model/
COPY ModernECommerce.Commaon/ModernECommerce.Common.csproj ModernECommerce.Commaon/
COPY DAL/DAL.csproj DAL/
COPY CatelogService.DAL/CatelogService.DAL.csproj CatelogService.DAL/
COPY CatalogService.Business/CatalogService.Business.csproj CatalogService.Business/
COPY CatelogService.DTO/CatelogService.DTO.csproj CatelogService.DTO/


# Restore the project
RUN dotnet restore CatelogService.API/CatelogService.API.csproj
COPY . .
WORKDIR /src/CatelogService.API
RUN dotnet build CatelogService.API.csproj -c Release -o /app

# Publish to the folder
FROM build AS publish
RUN dotnet publish CatelogService.API.csproj -c Release -o /app

# adding comments to understand what is happening

FROM base AS final
WORKDIR /app
#ENV ASPNETCORE_URLS http://+83
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CatelogService.API.dll"]
