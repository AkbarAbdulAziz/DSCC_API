FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["API_10547/API_10547.csproj", "API_10547/"]
RUN dotnet restore "API_10547/API_10547.csproj"
COPY . .
WORKDIR "/src/API_10547"
RUN dotnet build "API_10547.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API_10547.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API_10547.dll"]
