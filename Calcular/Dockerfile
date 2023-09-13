#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Calcular/Calcular.csproj", "Calcular/"]
RUN dotnet restore "Calcular/Calcular.csproj"
COPY . .
WORKDIR "/src/Calcular"
RUN dotnet build "Calcular.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Calcular.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Calcular.dll"]