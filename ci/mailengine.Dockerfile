# Dockerfile to build Pub Mailer image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
COPY . /app
WORKDIR /app

RUN dotnet restore MailEngine/MailEngine.csproj
RUN dotnet publish MailEngine/MailEngine.csproj -c Release -o out
 
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MailEngine.dll"]