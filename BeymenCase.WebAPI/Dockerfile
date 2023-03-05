#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BeymenCase.WebAPI/BeymenCase.WebAPI.csproj", "BeymenCase.WebAPI/"]
COPY ["BeymenCase.Service/BeymenCase.Service.csproj", "BeymenCase.Service/"]
COPY ["BeymenCase.Data/BeymenCase.Data.csproj", "BeymenCase.Data/"]
COPY ["BeymenCase.Core/BeymenCase.Core.csproj", "BeymenCase.Core/"]
COPY ["BeymenCase.ConfLib/BeymenCase.ConfLib.csproj", "BeymenCase.ConfLib/"]
RUN dotnet restore "BeymenCase.WebAPI/BeymenCase.WebAPI.csproj"
COPY . .
WORKDIR "/src/BeymenCase.WebAPI"
RUN dotnet build "BeymenCase.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BeymenCase.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BeymenCase.WebAPI.dll"]