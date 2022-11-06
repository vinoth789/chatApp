FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj files as distinct layers.
# This is done because of the Docker's built in cache
# If we do not have changes in .csproj files
# Docker will not execute dotnet restore 
COPY Backend/*.sln ./
COPY Backend/*.csproj ./
RUN dotnet restore

COPY Backend/ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Backend.dll"]