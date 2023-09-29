#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AwesomeShop.Services.Orders.API/AwesomeShop.Services.Orders.API.csproj", "src/AwesomeShop.Services.Orders.API/"]
COPY ["src/AwesomeShop.Services.Orders.Application/AwesomeShop.Services.Orders.Application.csproj", "src/AwesomeShop.Services.Orders.Application/"]
COPY ["src/AwesomeShop.Services.Orders.Domain/AwesomeShop.Services.Orders.Domain.csproj", "src/AwesomeShop.Services.Orders.Domain/"]
COPY ["src/AwesomeShop.Services.Orders.Infrastructure/AwesomeShop.Services.Orders.Infrastructure.csproj", "src/AwesomeShop.Services.Orders.Infrastructure/"]
RUN dotnet restore "src/AwesomeShop.Services.Orders.API/AwesomeShop.Services.Orders.API.csproj"
COPY . .
WORKDIR "/src/src/AwesomeShop.Services.Orders.API"
RUN dotnet build "AwesomeShop.Services.Orders.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AwesomeShop.Services.Orders.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AwesomeShop.Services.Orders.API.dll"]
