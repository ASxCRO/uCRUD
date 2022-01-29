#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["uCRUD/Server/uCRUD.Server.csproj", "uCRUD/Server/"]
COPY ["uCRUD/Shared/uCRUD.Shared.csproj", "uCRUD/Shared/"]
COPY ["uCRUD/Client/uCRUD.Client.csproj", "uCRUD/Client/"]
RUN dotnet restore "uCRUD/Server/uCRUD.Server.csproj"
COPY . .
WORKDIR "/src/uCRUD/Server"
RUN dotnet build "uCRUD.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "uCRUD.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "uCRUD.Server.dll"]