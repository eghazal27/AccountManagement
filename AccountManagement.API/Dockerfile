#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["./AccountManagement.API.csproj", "AccountManagement.API/"]
COPY ["./AccountManagement.Domain/AccountManagement.Domain.csproj", "AccountManagement.Domain/"]
COPY ["./AccountManagement.Infrastructure/AccountManagement.Infrastructure.csproj", "AccountManagement.Infrastructure/"]
COPY ["./AccountManagement.Services/AccountManagement.Services.csproj", "AccountManagement.Services/"]

COPY ["AccountManagement.API.csproj", "."]
RUN dotnet restore "./AccountManagement.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AccountManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AccountManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AccountManagement.API.dll"]