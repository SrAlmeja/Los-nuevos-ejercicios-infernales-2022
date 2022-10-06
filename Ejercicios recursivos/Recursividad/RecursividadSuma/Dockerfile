FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Recursividad/Recursividad.csproj", "Recursividad/"]
RUN dotnet restore "Recursividad/Recursividad.csproj"
COPY . .
WORKDIR "/src/Recursividad"
RUN dotnet build "Recursividad.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recursividad.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Recursividad.dll"]
