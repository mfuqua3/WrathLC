FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG CONFIGURATION
WORKDIR /src
COPY ["GuildView.Idp/GuildView.Idp.csproj", "GuildView.Idp/"]
COPY ["GuildView.Idp.ResourceAccess/GuildView.Idp.ResourceAccess.csproj", "GuildView.Idp.ResourceAccess/"]
COPY ["GuildView.Common.ResourceAccess/GuildView.Common.ResourceAccess.csproj", "GuildView.Common.ResourceAccess/"]
COPY ["GuildView.Common.Utilities/GuildView.Common.Utilities.csproj", "GuildView.Common.Utilities/"]
COPY ["GuildView.Idp.Data/GuildView.Idp.Data.csproj", "GuildView.Idp.Data/"]
COPY ["GuildView.Idp.Managers/GuildView.Idp.Managers.csproj", "GuildView.Idp.Managers/"]
RUN dotnet restore "GuildView.Idp/GuildView.Idp.csproj"
COPY . .
WORKDIR "/src/GuildView.Idp"
RUN dotnet build "GuildView.Idp.csproj" -c $CONFIGURATION -o /app/build

FROM build AS publish
ARG CONFIGURATION
RUN dotnet publish "GuildView.Idp.csproj" -c $CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GuildView.Idp.dll"]
