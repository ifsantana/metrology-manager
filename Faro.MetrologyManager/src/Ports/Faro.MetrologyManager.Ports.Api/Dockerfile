#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /app
COPY . ./
WORKDIR "/app/Faro.MetrologyManager.Ports.Api"
RUN dotnet restore
#RUN dotnet build "Faro.MetrologyManager.Ports.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Faro.MetrologyManager.Ports.Api.csproj" -c Release -o out

FROM base AS final
WORKDIR /app
COPY --from=publish /app/Faro.MetrologyManager.Ports.Api/out .
ENTRYPOINT ["dotnet", "Faro.MetrologyManager.Ports.Api.dll"]