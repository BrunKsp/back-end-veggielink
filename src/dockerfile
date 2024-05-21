FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/api/ABO.VeggieLink.Api.csproj", "src/api/"]
RUN dotnet restore "src/api/VeggieLink.Api.csproj" -p:HUSKY=0
COPY . .
WORKDIR "/src/src/api"
RUN dotnet build "VeggieLink.Api.csproj" -c Release -o /app/build -p:HUSKY=0

FROM build AS publish
RUN dotnet publish "VeggieLink.Api.csproj" -c Release -o /app/publish -p:HUSKY=0

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet VeggieLink.Api.dll