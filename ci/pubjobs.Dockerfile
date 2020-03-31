FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
COPY . /app
WORKDIR /app

RUN dotnet restore PubJobs/PubJobs.csproj
RUN dotnet publish PubJobs/PubJobs.csproj  -c Release -o out
 
# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ARG PUB_API_ENDPOINT
ENV PubApiEndpoint=$PUB_API_ENDPOINT
ARG API_KEY
ENV ApiKey=$API_KEY

ARG TABLE_STORAGE_CONNECTION_STRING
ENV TableStorageConnectionString=$TABLE_STORAGE_CONNECTION_STRING
ARG STORAGE_TABLE_NAME
ENV StorageTableName=$STORAGE_TABLE_NAME
ARG MAIL_TRACKING_TABLE_NAME
ENV MailTrackingTableName=$MAIL_TRACKING_TABLE_NAME

ARG SERVICE_BUS_CONNECTION_STRING
ENV ServiceBusConnectionString=$SERVICE_BUS_CONNECTION_STRING
ARG SERVICE_BUS_QUEUE_NAME
ENV ServiceBusQueueName=$SERVICE_BUS_QUEUE_NAME

ARG SEND_GRID_TEMPLATES_API_KEY
ENV SendGridTemplatesApiKey=$SEND_GRID_TEMPLATES_API_KEY

WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "PubJobs.dll"]