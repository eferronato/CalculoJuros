#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Softplan.Juros.TaxaJurosAPI/Softplan.Juros.TaxaJurosAPI.csproj", "Softplan.Juros.TaxaJurosAPI/"]
COPY ["Softplan.Juros.Service/Softplan.Juros.Service.csproj", "Softplan.Juros.Service/"]
COPY ["Softplan.Utils/Softplan.Utils.csproj", "Softplan.Utils/"]
RUN dotnet restore "Softplan.Juros.TaxaJurosAPI/Softplan.Juros.TaxaJurosAPI.csproj"
COPY . .
WORKDIR "/src/Softplan.Juros.TaxaJurosAPI"
RUN dotnet build "Softplan.Juros.TaxaJurosAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Softplan.Juros.TaxaJurosAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Softplan.Juros.TaxaJurosAPI.dll"]
