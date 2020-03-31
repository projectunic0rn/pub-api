FROM microsoft/dotnet:2.2-sdk AS build-env
COPY . /app
WORKDIR /app

RUN dotnet restore SlackApp/SlackApp.csproj
RUN dotnet publish SlackApp/SlackApp.csproj -c Release -o out
 
# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
ARG CONNECTION_STRING
ENV ConnectionString=$CONNECTION_STRING
ARG APP_URL
ENV AppUrl=$APP_URL
ARG MAIN_URL
ENV MainUrl=$MAIN_URL
ARG SLACK_AUTH_TOKEN
ENV SlackAuthToken=$SLACK_AUTH_TOKEN
ARG SLACK_SIGNING_SECRET
ENV SlackSigningSecret=$SLACK_SIGNING_SECRET
ARG INTRODUCTION_CHANNEL_ID
ENV IntroductionChannelId=$INTRODUCTION_CHANNEL_ID
ARG GITHUB_APP_PRIVATE_RSA_KEY
ENV GithubAppPrivateRSAKey=$GITHUB_APP_PRIVATE_RSA_KEY
ARG GITHUB_APP_ID
ENV GithubAppId=$GITHUB_APP_ID
ARG GITHUB_APP_INSTALLATION_ID
ENV GithubAppInstallationId=$GITHUB_APP_INSTALLATION_ID
ARG GITHUB_ORGANIZATION
ENV GithubOrganization=$GITHUB_ORGANIZATION
ARG PRIVILEGED_MEMBERS
ENV PrivilegedMembers=$PRIVILEGED_MEMBERS

WORKDIR /app
COPY --from=build-env /app/SlackApp/out .
ENTRYPOINT ["dotnet", "SlackApp.dll"]