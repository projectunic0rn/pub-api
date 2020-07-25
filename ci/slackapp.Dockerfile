FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
COPY . /app
WORKDIR /app

RUN dotnet restore SlackApp/SlackApp.csproj
RUN dotnet publish SlackApp/SlackApp.csproj -c Release -o out
 
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SlackApp.dll"]