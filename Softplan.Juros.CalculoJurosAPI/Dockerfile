#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Softplan.Juros.CalculoJurosAPI/Softplan.Juros.CalculoJurosAPI.csproj", "Softplan.Juros.CalculoJurosAPI/"]
COPY ["Softplan.Juros.Service/Softplan.Juros.Service.csproj", "Softplan.Juros.Service/"]
COPY ["Softplan.Utils/Softplan.Utils.csproj", "Softplan.Utils/"]
RUN dotnet restore "Softplan.Juros.CalculoJurosAPI/Softplan.Juros.CalculoJurosAPI.csproj"
COPY . .
WORKDIR "/src/Softplan.Juros.CalculoJurosAPI"
RUN dotnet build "Softplan.Juros.CalculoJurosAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Softplan.Juros.CalculoJurosAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Softplan.Juros.CalculoJurosAPI.dll"]
