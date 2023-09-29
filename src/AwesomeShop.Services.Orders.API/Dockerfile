FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/AwesomeShop.Services.Orders.API/AwesomeShop.Services.Orders.API.csproj", "src/AwesomeShop.Services.Orders.API/"]

COPY . .
WORKDIR "/src/src/AwesomeShop.Services.Orders.API"

FROM build AS publish
RUN dotnet publish "AwesomeShop.Services.Orders.API.csproj" -c Release -o /app/publish

ENV TZ=America/Sao_Paulo
ENV LANG pt-BR
ENV LANGUAGE pt-BR
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AwesomeShop.Services.Orders.API.dll"]