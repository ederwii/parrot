# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Api/*.csproj ./Api/
COPY Data/*.csproj ./Data/
COPY Doman/*.csproj ./Doman/
COPY Logic/*.csproj ./Logic/
RUN dotnet restore

# copy everything else and build app
COPY Api/. ./Api/
WORKDIR /source/Api
RUN dotnet publish -c debug -o /app 

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Api.dll"]
