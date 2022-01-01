FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Applicative.Functors.Main/Applicative.Functors.Main.fsproj", "Applicative.Functors.Main/"]
RUN dotnet restore "Applicative.Functors.Main/Applicative.Functors.Main.fsproj"
COPY . .
WORKDIR "/src/Applicative.Functors.Main"
RUN dotnet build "Applicative.Functors.Main.fsproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Applicative.Functors.Main.fsproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Applicative.Functors.Main.dll"]
