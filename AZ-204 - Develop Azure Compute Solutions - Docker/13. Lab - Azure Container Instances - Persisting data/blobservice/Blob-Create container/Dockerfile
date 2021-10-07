FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Blob-Create container/blobproject.csproj", "Blob-Create container/"]
RUN dotnet restore "Blob-Create container/blobproject.csproj"
COPY . .
WORKDIR "/src/Blob-Create container"
RUN dotnet build "blobproject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "blobproject.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "blobproject.dll"]