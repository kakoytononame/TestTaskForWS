FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TestForRest/TestForRest.csproj", "TestForRest/"]
RUN dotnet restore "TestForRest/TestForRest.csproj"
COPY . .
WORKDIR "/src/TestForRest"
RUN dotnet build "TestForRest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestForRest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestForRest.dll"]
