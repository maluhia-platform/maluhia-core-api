FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/WebAPI/WebAPI.csproj", "src/WebAPI/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]

COPY ["test/WebAPI.Tests/WebAPI.Tests.csproj", "test/WebAPI.Tests/"]
COPY ["test/Application.Tests/Application.Tests.csproj", "test/Application.Tests/"]
COPY ["test/Domain.Tests/Domain.Tests.csproj", "test/Domain.Tests/"]
COPY ["test/Infrastructure.Tests/Infrastructure.Tests.csproj", "test/Infrastructure.Tests/"]

RUN dotnet restore "src/WebAPI/WebAPI.csproj"

COPY . .

FROM build AS unit-test
RUN dotnet test "Maluhia.Core.sln" 

WORKDIR "src/WebAPI"
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
