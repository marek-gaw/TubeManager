# TubeManager - infrastructure

This directory contains files related to the infrastructure/deployment process.

## How to run project locally

1. Run services

    ```bash
    docker compose up -d
    ```

2. (optional) Run PgAdmin

    ```bash
    docker pull dpage/pgadmin4
    docker run -p 5050:80 \
        -e "PGADMIN_DEFAULT_EMAIL=user@domain.com" \
        -e "PGADMIN_DEFAULT_PASSWORD=SuperSecret" \
        -d dpage/pgadmin4
    ```

3. Create database schema

    Run [script](./db_setup.sql):

    ```sql
    CREATE ROLE docker
    create user docker

    SELECT rolname FROM pg_roles WHERE rolcanlogin;

    alter role docker login
    grant admin to marek with inherit true

    ALTER DATABASE tubemanager OWNER TO marek;
    GRANT USAGE, CREATE ON SCHEMA public TO marek

    grant all privileges on database tubemanager to docker;
    grant all privileges on all tables in schema public to docker;
    grant all privileges on all sequences in schema public to docker;
    grant all privileges on all functions in schema public to docker;
    GRANT CREATE ON SCHEMA public TO docker;
    ```

4. Run database migrations

    ```bash
    cd <project_src>/TubeManager/src/service/TubeManager.Infrastructure
    dotnet ef database update --startup-project ../TubeManager.API --context BookmarksDbContext
    ```
