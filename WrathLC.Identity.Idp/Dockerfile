FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG CONFIGURATION
WORKDIR /src
COPY ["WrathLC.Identity.Idp/WrathLC.Identity.Idp.csproj", "WrathLC.Identity.Idp/"]
COPY ["WrathLC.Identity.Data/WrathLC.Identity.Data.csproj", "WrathLC.Identity.Data/"]
COPY ["WrathLC.Identity.Utility/WrathLC.Identity.Utility.csproj", "WrathLC.Identity.Utility/"]
COPY ["WrathLC.Identity.Business/WrathLC.Identity.Business.csproj", "WrathLC.Identity.Business/"]
COPY ["WrathLC.Data.Common/WrathLC.Data.Common.csproj", "WrathLC.Data.Common/"]
COPY ["WrathLC.Utility.Common/WrathLC.Utility.Common.csproj", "WrathLC.Utility.Common/"]
RUN dotnet restore "WrathLC.Identity.Idp/WrathLC.Identity.Idp.csproj"
COPY . .
WORKDIR "/src/WrathLC.Identity.Idp"
RUN dotnet build "WrathLC.Identity.Idp.csproj" -c $CONFIGURATION -o /app/build

FROM build AS publish
ARG CONFIGURATION
RUN dotnet publish "WrathLC.Identity.Idp.csproj" -c $CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WrathLC.Identity.Idp.dll"]
