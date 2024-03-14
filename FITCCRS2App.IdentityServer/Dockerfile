FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FITCCRS2App.IdentityServer/FITCCRS2App.IdentityServer.csproj", "FITCCRS2App.IdentityServer/"]
RUN dotnet restore "FITCCRS2App.IdentityServer/FITCCRS2App.IdentityServer.csproj"
COPY . .
WORKDIR "/src/FITCCRS2App.IdentityServer"
RUN dotnet build "FITCCRS2App.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FITCCRS2App.IdentityServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FITCCRS2App.IdentityServer.dll"]