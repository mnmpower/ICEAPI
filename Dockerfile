FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore && dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

RUN apt-get update 

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "iceapi.dll"]