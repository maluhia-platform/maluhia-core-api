FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Maluhia.Core.Api/Maluhia.Core.Api.csproj", "Maluhia.Core.Api/"]
RUN dotnet restore "src/Maluhia.Core.Api/Maluhia.Core.Api.csproj"
COPY . .
WORKDIR "/src/Maluhia.Core.Api"
RUN dotnet build "Maluhia.Core.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Maluhia.Core.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Maluhia.Core.Api.dll"]
