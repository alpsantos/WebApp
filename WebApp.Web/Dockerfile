FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

ENV INFO_VAR = "VAR_DOCKFILE"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WebApp.Web.csproj", "WebApp.Web/"]

WORKDIR "/src/WebApp.Web"
RUN dotnet restore "WebApp.Web.csproj"
COPY . .

RUN dotnet build "WebApp.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApp.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp.Web.dll"] 