#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

COPY ["src/AltPoint.Api/AltPoint.Api.csproj", "AltPoint.Api/"]
COPY ["src/AltPoint.Application/AltPoint.Application.csproj", "AltPoint.Application/"]
COPY ["src/AltPoint.Domain/AltPoint.Domain.csproj", "AltPoint.Domain/"]
COPY ["src/AltPoint.Infrastructure/AltPoint.Infrastructure.csproj", "AltPoint.Infrastructure/"]

RUN dotnet restore "AltPoint.Api/AltPoint.Api.csproj"
COPY src/ .

WORKDIR "/AltPoint.Api"
RUN dotnet build "AltPoint.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AltPoint.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AltPoint.Api.dll"]