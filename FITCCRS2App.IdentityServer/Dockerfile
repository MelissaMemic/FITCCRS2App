# Use the runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5443
ENV ASPNETCORE_URLS=http://+:5443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "FITCCRS2App.IdentityServer.csproj" -c Release -o /app

# Final stage
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FITCCRS2App.IdentityServer.dll"]