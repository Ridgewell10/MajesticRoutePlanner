FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY MajesticRoutePlanner.Api/ MajesticRoutePlanner.Api/
COPY MajesticRoutePlanner.Application/ MajesticRoutePlanner.Application/
COPY MajesticRoutePlanner.Domain/ MajesticRoutePlanner.Domain/
COPY MajesticRoutePlanner.Infrastructure/ MajesticRoutePlanner.Infrastructure/
COPY MajesticRoutePlanner.Tests/ MajesticRoutePlanner.Tests/
COPY MajesticRoutePlanner.sln ./

RUN dotnet restore MajesticRoutePlanner.sln
RUN dotnet publish MajesticRoutePlanner.Api/MajesticRoutePlanner.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 5050

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MajesticRoutePlanner.Api.dll"]