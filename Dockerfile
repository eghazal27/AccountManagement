FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR .
COPY ["AccountManagement.API/AccountManagement.API.csproj", "AccountManagement/AccountManagement.API/"]
COPY ["AccountManagement.Domain/AccountManagement.Domain.csproj", "AccountManagement/AccountManagement.Domain/"]
COPY ["AccountManagement.Service/AccountManagement.Service.csproj", "AccountManagement/AccountManagement.Service/"]
COPY ["AccountManagement.Infrastructure/AccountManagement.Infrastructure.csproj", "AccountManagement/AccountManagement.Infrastructure/"]


COPY . .
WORKDIR "/src/AccountManagement/AccountManagement.API/AccountManagement.API"

RUN dotnet build "AccountManagement.API.csproj"  -c Release -o /app/build

#FROM build AS publish
RUN dotnet publish "AccountManagement.API.csproj" -c Release  -o /app/publish

#FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountManagement.API.dll"]