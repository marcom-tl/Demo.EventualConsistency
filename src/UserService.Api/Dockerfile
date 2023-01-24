#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/UserService.Api/UserService.Api.csproj", "src/UserService.Api/"]
RUN dotnet restore "src/UserService.Api/UserService.Api.csproj"
COPY . .
WORKDIR "/src/src/UserService.Api"
RUN dotnet build "UserService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserService.Api.dll"]