ARG SDK_VERSION=9.0.301
FROM mcr.microsoft.com/dotnet/sdk:${SDK_VERSION} AS prepare
WORKDIR /

COPY . . 

RUN dotnet restore Globalization.sln

COPY . ./

RUN dotnet build Globalization.sln --no-restore

FROM prepare AS build

RUN dotnet build --no-restore -c Release

WORKDIR /src
RUN dotnet publish -c Release -r linux-musl-arm64 -p:PublishReadyToRun=true -p:PublishTrimmed=true -p:PublishSingleFile=true -o out

FROM ghcr.io/sahma19/minimal-dotnet:runtime-deps-9.0 AS runtime

WORKDIR /app
COPY --from=build --chown=$USER:$USER /src/out ./
ENTRYPOINT ["./Globalization"]
