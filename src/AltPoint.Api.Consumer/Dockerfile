#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

COPY ["src/AltPoint.Api.Consumer/AltPoint.Api.Consumer.csproj", "AltPoint.Api.Consumer/"]

RUN dotnet restore "AltPoint.Api.Consumer/AltPoint.Api.Consumer.csproj"

WORKDIR "/AltPoint.Api.Consumer"

COPY src/AltPoint.Api.Consumer/ .

RUN dotnet build "AltPoint.Api.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AltPoint.Api.Consumer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AltPoint.Api.Consumer.dll"]