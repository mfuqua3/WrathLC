FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WrathLC.HangfireWorker/WrathLC.HangfireWorker.csproj", "WrathLC.HangfireWorker/"]
COPY ["WrathLC.Core.Data/WrathLC.Core.Data.csproj", "WrathLC.Core.Data/"]
COPY ["WrathLC.Core.Utility/WrathLC.Core.Data.csproj", "WrathLC.Core.Utility/"]
COPY ["WrathLC.Core.Business/WrathLC.Core.Business.csproj", "WrathLC.Core.Business/"]
COPY ["WrathLC.Data.Common/WrathLC.Data.Common.csproj", "WrathLC.Data.Common/"]
COPY ["WrathLC.Utility.Common/WrathLC.Utility.Common.csproj", "WrathLC.Utility.Common/"]
RUN dotnet restore "WrathLC.Core.HangfireWorker/WrathLC.Core.HangfireWorker.csproj"
COPY . .
WORKDIR "/src/WrathLC.HangfireWorker"
RUN dotnet build "WrathLC.Core.HangfireWorker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WrathLC.Core.HangfireWorker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WrathLC.Core.HangfireWorker.dll"]
