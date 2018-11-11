FROM microsoft/dotnet:2.1.2-aspnetcore-runtime AS base
#FROM microsoft/dotnet:2.1-runtime-deps-alpine3.7
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY CatelogService.API/CatelogService.API.csproj CatelogService.API/
COPY CatelogService.Model/CatelogService.Model.csproj CatelogService.Model/
COPY ModernECommerce.Commaon/ModernECommerce.Common.csproj ModernECommerce.Commaon/
COPY DAL/DAL.csproj DAL/
COPY CatelogService.DAL/CatelogService.DAL.csproj CatelogService.DAL/
COPY CatalogService.Business/CatalogService.Business.csproj CatalogService.Business/
COPY CatelogService.DTO/CatelogService.DTO.csproj CatelogService.DTO/
RUN dotnet restore CatelogService.API/CatelogService.API.csproj
COPY . .
WORKDIR /src/CatelogService.API
RUN dotnet build CatelogService.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CatelogService.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
#ENV ASPNETCORE_URLS http://+83
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CatelogService.API.dll"]
