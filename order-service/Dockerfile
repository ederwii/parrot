# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY PR.Api/*.csproj ./PR.Api/
COPY PR.Data/*.csproj ./PR.Data/
COPY PR.Domain/*.csproj ./PR.Domain/
COPY PR.Logic/*.csproj ./PR.Logic/
RUN dotnet restore

# copy everything else and build app
COPY PR.Api/. ./PR.Api/
COPY PR.Data/. ./PR.Data/
COPY PR.Domain/. ./PR.Domain/
COPY PR.Logic/. ./PR.Logic/
WORKDIR /source/PR.Api
RUN dotnet publish -c release -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "PR.Api.dll"]
