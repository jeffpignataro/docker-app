# Dockerized Dotnet Core Application

## Database configuration
Create [.env file](https://docs.docker.com/compose/environment-variables/#/the-env-file) for managing environment configuration for MySQL.

Sample `db.env`:

```
MYSQL_ROOT_PASSWORD=root-password
MYSQL_USER=basic-user
MYSQL_PASSWORD=base-user-password
MYSQL_DATABASE=database-name
```

This file can be placed any where in the project, but the default docker-compose expects the file at `./config/db.env`.

## Deploying default containers
The default VS Code task executes the following:
`docker compose up --build --force-recreate --detach`