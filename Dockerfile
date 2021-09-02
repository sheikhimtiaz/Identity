# FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
# WORKDIR /app
# EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app


COPY Identity.csproj ./
RUN dotnet restore


COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Identity.dll"]











# FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
# WORKDIR /src
# COPY ["Identity.csproj", "src/"]
# COPY ["Identity/NuGet.Config", "/root/.nuget/NuGet/NuGet.Config"]

# RUN dotnet restore "src/Identity.csproj"
# COPY / .
# WORKDIR /src
# RUN dotnet build "src/Identity.csproj" -c Release -o /app/build
# RUN dotnet test "tests/Identity.csproj" --results-directory /testresults --logger "trx;LogFileName==IdentityUnitTests.trx" --collect:"XPlat Code Coverage"
# LABEL test=true

# FROM build AS publish
# RUN dotnet publish "src/Identity.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Identity.dll"]