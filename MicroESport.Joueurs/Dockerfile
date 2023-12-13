FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroESport.Joueur.csproj", ""]
RUN dotnet restore "MicroESport.Joueur.csproj"
COPY . .

RUN dotnet build "MicroESport.Joueur.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroESport.Joueur.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroESport.Joueur.dll"]
