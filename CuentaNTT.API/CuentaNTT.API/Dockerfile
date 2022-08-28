#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CuentaNTT.API/CuentaNTT.API.csproj", "CuentaNTT.API/"]
COPY ["CuentaNTT.Repository/CuentaNTT.Repository.csproj", "CuentaNTT.Repository/"]
COPY ["Cuenta.Core/CuentaNTT.Core.csproj", "Cuenta.Core/"]
COPY ["CuentaNTT.Business/CuentaNTT.Business.csproj", "CuentaNTT.Business/"]
RUN dotnet restore "CuentaNTT.API/CuentaNTT.API.csproj"
COPY . .
WORKDIR "/src/CuentaNTT.API"
RUN dotnet build "CuentaNTT.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CuentaNTT.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CuentaNTT.API.dll"]