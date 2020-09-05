#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

ENV INFO_VAR = "VAR_DOCKFILE"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WebApp.Web/WebApp.Web.csproj", "WebApp.Web/"]
RUN dotnet restore "WebApp.Web/WebApp.Web.csproj"
COPY . .
WORKDIR "/src/WebApp.Web"
RUN dotnet build "WebApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp.Web.dll"]