# KéMkas

Kard és Mágia karakter alkotó segédlet (https://app.kemkas.hu)

\[EN] Please excuse the Hungish, the domain language of KéM is hungarian, but the domain language of programming is english, which resulted in this monster.

\[HU] Kérlek nézd el a kevert angol kifejezeséket, ugyan a szerepáték nyelve magyar, de a programozás szakmai nyelve angol.

## Deployment

See deployment repo at: [https://github.com/morbalint/kemkas-deployment](https://github.com/morbalint/kemkas-deployment)

![CI workflow](https://github.com/morbalint/kemkas-backend/actions/workflows/ci.yml/badge.svg)

## Coding readmes

For frontend see: [Frontend README](https://github.com/morbalint/kemkas/README.md)

To start development, spin up the docker-compose.yaml file and use the launchSettings.json to start the backend dev server. Use the frontend repo to start the frontend dev server.

For the first time setup:
```shell
dotnet dev-certs https --clean && \
dotnet dev-certs https --format PEM --no-password -ep ~/.aspnet/https/kemkas.pem
```

Later start the docker compose first and the project launch settings after the DB is up and running. 

## Unit tests

Run backend unit tests from the repository root:

```shell
dotnet test Kemkas.slnx -c Release
```

