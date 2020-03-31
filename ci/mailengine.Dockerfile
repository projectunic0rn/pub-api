# Dockerfile to build Pub Mailer image
FROM microsoft/dotnet:2.2-sdk AS build-env
COPY . /app
WORKDIR /app

RUN dotnet restore MailEngine/MailEngine.csproj
RUN dotnet publish MailEngine/MailEngine.csproj -c Release -o out
 
# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
ARG CONNECTION_STRING
ENV ConnectionString=$CONNECTION_STRING
ARG SERVICE_BUS_CONNECTION_STRING
ENV ServiceBusConnectionString=$SERVICE_BUS_CONNECTION_STRING
ARG SERVICE_BUS_QUEUE_NAME
ENV ServiceBusQueueName=$SERVICE_BUS_QUEUE_NAME
ARG SEND_GRID_TEMPLATES_API_KEY
ENV SendGridTemplatesApiKey=$SEND_GRID_TEMPLATES_API_KEY

ARG APP_URL
ENV AppUrl=$APP_URL
ARG TABLE_STORAGE_CONNECTION_STRING
ENV TableStorageConnectionString=$TABLE_STORAGE_CONNECTION_STRING
ARG STORAGE_TABLE_NAME
ENV StorageTableName=$STORAGE_TABLE_NAME

ARG NETCORE_ENV
ENV ASPNETCORE_ENVIRONMENT=$NETCORE_ENV

WORKDIR /app
COPY --from=build-env /app/MailEngine/out .
ENTRYPOINT ["dotnet", "MailEngine.dll"]