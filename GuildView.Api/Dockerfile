FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG CONFIGURATION
WORKDIR /src
COPY ["GuildView.Api/GuildView.Api.csproj", "GuildView.Api/"]
COPY ["GuildView.Common.ResourceAccess/GuildView.Common.ResourceAccess.csproj", "GuildView.Common.ResourceAccess/"]
COPY ["GuildView.Common.Utilities/GuildView.Common.Utilities.csproj", "GuildView.Common.Utilities/"]
COPY ["GuildView.Core.Business/GuildView.Core.Business.csproj", "GuildView.Core.Business/"]
COPY ["GuildView.Core.Data/GuildView.Core.Data.csproj", "GuildView.Core.Data/"]
COPY ["GuildView.Core.ResourceAccess/GuildView.Core.ResourceAccess.csproj", "GuildView.Core.ResourceAccess/"]
RUN dotnet restore "GuildView.Api/GuildView.Api.csproj"
COPY . .
WORKDIR "/src/GuildView.Api"
RUN dotnet build "GuildView.Api.csproj" -c $CONFIGURATION -o /app/build

FROM build AS publish
ARG CONFIGURATION
RUN dotnet publish "GuildView.Api.csproj" -c $CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GuildView.Api.dll"]
