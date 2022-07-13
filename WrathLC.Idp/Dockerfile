FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG CONFIGURATION
WORKDIR /src
COPY ["WrathLC.Idp/WrathLC.Idp.csproj", "WrathLC.Idp/"]
COPY ["WrathLC.Idp.ResourceAccess/WrathLC.Idp.ResourceAccess.csproj", "WrathLC.Idp.ResourceAccess/"]
COPY ["WrathLC.Common.ResourceAccess/WrathLC.Common.ResourceAccess.csproj", "WrathLC.Common.ResourceAccess/"]
COPY ["WrathLC.Common.Utilities/WrathLC.Common.Utilities.csproj", "WrathLC.Common.Utilities/"]
COPY ["WrathLC.Idp.Data/WrathLC.Idp.Data.csproj", "WrathLC.Idp.Data/"]
COPY ["WrathLC.Idp.Managers/WrathLC.Idp.Managers.csproj", "WrathLC.Idp.Managers/"]
RUN dotnet restore "WrathLC.Idp/WrathLC.Idp.csproj"
COPY . .
WORKDIR "/src/WrathLC.Idp"
RUN dotnet build "WrathLC.Idp.csproj" -c $CONFIGURATION -o /app/build

FROM build AS publish
ARG CONFIGURATION
RUN dotnet publish "WrathLC.Idp.csproj" -c $CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WrathLC.Idp.dll"]
