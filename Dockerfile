FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy csproj files and restore for both projects
COPY DAir_Airlines/DAir_Airlines.csproj DAir_Airlines/
COPY Database/Database.csproj Database/

RUN dotnet restore DAir_Airlines/DAir_Airlines.csproj
RUN dotnet restore Database/Database.csproj

# Copy the entire solution directory (excluding the things listed in .dockerignore if you have one)
COPY . .

# Build the DAir_Airlines project
WORKDIR "/src/DAir_Airlines"
RUN dotnet build "DAir_Airlines.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DAir_Airlines.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DAir_Airlines.dll"]
