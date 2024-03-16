FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
 
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
 
FROM build AS publish
RUN dotnet publish "FITCCRS2App.IdentityServer\FITCCRS2App.IdentityServer.csproj" -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
 
COPY ["FITCCRS2App.IdentityServer/certificate.pfx", "/app/"]
 
ENTRYPOINT ["dotnet", "FITCCRS2App.IdentityServer.dll"]
