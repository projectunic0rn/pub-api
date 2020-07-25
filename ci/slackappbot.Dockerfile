FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env

COPY . /app
WORKDIR /app

RUN dotnet restore SlackAppBot/SlackAppBot.csproj
RUN dotnet publish SlackAppBot/SlackAppBot.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SlackAppBot.dll"]