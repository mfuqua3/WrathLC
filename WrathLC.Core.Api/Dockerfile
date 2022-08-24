FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG CONFIGURATION
WORKDIR /src
COPY ["WrathLC.Core.Api/WrathLC.Core.Api.csproj", "WrathLC.Core.Api/"]
COPY ["WrathLC.Core.Data/WrathLC.Core.Data.csproj", "WrathLC.Core.Data/"]
COPY ["WrathLC.Core.Utility/WrathLC.Core.Utility.csproj", "WrathLC.Core.Utility/"]
COPY ["WrathLC.Core.Business/WrathLC.Core.Business.csproj", "WrathLC.Core.Business/"]
COPY ["WrathLC.Data.Common/WrathLC.Data.Common.csproj", "WrathLC.Data.Common/"]
COPY ["WrathLC.Utility.Common/WrathLC.Utility.Common.csproj", "WrathLC.Utility.Common/"]
RUN dotnet restore "WrathLC.Core.Api/WrathLC.Core.Api.csproj"
COPY . .
WORKDIR "/src/WrathLC.Core.Api"
RUN dotnet build "WrathLC.Core.Api.csproj" -c $CONFIGURATION -o /app/build

FROM build AS publish
ARG CONFIGURATION
RUN dotnet publish "WrathLC.Core.Api.csproj" -c $CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WrathLC.Core.Api.dll"]
