FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DAir_Airlines/DAir_Airlines.csproj", "DAir_Airlines/"]
RUN dotnet restore "DAir_Airlines/DAir_Airlines.csproj"
COPY . .
WORKDIR "/src/DAir_Airlines"
RUN dotnet build "DAir_Airlines.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DAir_Airlines.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DAir_Airlines.dll"]