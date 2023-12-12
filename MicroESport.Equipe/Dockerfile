FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroESport.Equipe/MicroESport.Equipe.csproj", "MicroESport.Equipe/"]
RUN dotnet restore "MicroESport.Equipe/MicroESport.Equipe.csproj"
COPY . .
WORKDIR "/src/MicroESport.Equipe"
RUN dotnet build "MicroESport.Equipe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroESport.Equipe.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroESport.Equipe.dll"]
