FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG CONFIGURATION
WORKDIR /src
COPY ["WrathLC.Api/WrathLC.Api.csproj", "WrathLC.Api/"]
COPY ["WrathLC.Common.ResourceAccess/WrathLC.Common.ResourceAccess.csproj", "WrathLC.Common.ResourceAccess/"]
COPY ["WrathLC.Common.Utilities/WrathLC.Common.Utilities.csproj", "WrathLC.Common.Utilities/"]
COPY ["WrathLC.Core.Business/WrathLC.Core.Business.csproj", "WrathLC.Core.Business/"]
COPY ["WrathLC.Core.Data/WrathLC.Core.Data.csproj", "WrathLC.Core.Data/"]
COPY ["WrathLC.Core.ResourceAccess/WrathLC.Core.ResourceAccess.csproj", "WrathLC.Core.ResourceAccess/"]
RUN dotnet restore "WrathLC.Api/WrathLC.Api.csproj"
COPY . .
WORKDIR "/src/WrathLC.Api"
RUN dotnet build "WrathLC.Api.csproj" -c $CONFIGURATION -o /app/build

FROM build AS publish
ARG CONFIGURATION
RUN dotnet publish "WrathLC.Api.csproj" -c $CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WrathLC.Api.dll"]
