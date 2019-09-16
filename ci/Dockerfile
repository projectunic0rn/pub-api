FROM microsoft/dotnet:2.2-sdk AS build-env
COPY . /app
WORKDIR /app

RUN dotnet restore 
RUN dotnet publish -c Release -o out
 
# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
ARG CONNECTION_STRING
ENV ConnectionString=$CONNECTION_STRING
ARG JWT_SECRET_KEY
ENV JwtSecretKey=$JWT_SECRET_KEY
ARG JWT_AUDIENCE
ENV JwtAudience=$JWT_AUDIENCE
ARG JWT_ISSUER
ENV JwtIssuer=$JWT_ISSUER
WORKDIR /app
COPY --from=build-env /app/API/out .
ENTRYPOINT ["dotnet", "API.dll"]