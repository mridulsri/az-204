#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WorkerServices_RG/WorkerServices_RG.csproj", "WorkerServices_RG/"]
RUN dotnet restore "WorkerServices_RG/WorkerServices_RG.csproj"
COPY . .
WORKDIR "/src/WorkerServices_RG"
RUN dotnet build "WorkerServices_RG.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WorkerServices_RG.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WorkerServices_RG.dll"]