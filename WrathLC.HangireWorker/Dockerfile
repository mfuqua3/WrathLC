FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WrathLC.HangireWorker/WrathLC.HangireWorker.csproj", "WrathLC.HangireWorker/"]
RUN dotnet restore "WrathLC.HangireWorker/WrathLC.HangireWorker.csproj"
COPY . .
WORKDIR "/src/WrathLC.HangireWorker"
RUN dotnet build "WrathLC.HangireWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WrathLC.HangireWorker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WrathLC.HangireWorker.dll"]
