#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DevIO.Api/DevIO.Api.csproj", "DevIO.Api/"]
COPY ["DevIO.Data/DevIO.Data.csproj", "DevIO.Data/"]
COPY ["DevIO.Business/DevIO.Business.csproj", "DevIO.Business/"]
RUN dotnet restore "DevIO.Api/DevIO.Api.csproj"
COPY . .
WORKDIR "/src/DevIO.Api"
RUN dotnet build "DevIO.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevIO.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevIO.Api.dll"]