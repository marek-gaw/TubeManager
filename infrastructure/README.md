# TubeManager - infrastructure

This directory contains files related to the infrastructure/deployment process.

## How to run project locally

```bash

# use PgAdmin to manage database
docker pull dpage/pgadmin4
docker run -p 5050:80 \
    -e "PGADMIN_DEFAULT_EMAIL=user@domain.com" \
    -e "PGADMIN_DEFAULT_PASSWORD=SuperSecret" \
    -d dpage/pgadmin4

# run services via docker compose

docker compose up -d  

```
## How to deploy

_TBD_
