FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WrathLC.HangfireWorker/WrathLC.HangfireWorker.csproj", "WrathLC.HangfireWorker/"]
RUN dotnet restore "WrathLC.HangfireWorker/WrathLC.HangfireWorker.csproj"
COPY . .
WORKDIR "/src/WrathLC.HangfireWorker"
RUN dotnet build "WrathLC.HangfireWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WrathLC.HangfireWorker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WrathLC.HangfireWorker.dll"]
