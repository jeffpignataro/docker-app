# Dockerized Dotnet Core Application

## Database configuration
Create [.env file](https://docs.docker.com/compose/environment-variables/#/the-env-file) for managing environment configuration for MySQL.

Sample `db.env`:

```
MYSQL_ROOT_PASSWORD=root-password
MYSQL_USER=basic-user
MYSQL_PASSWORD=basic-user-password
MYSQL_DATABASE=database-name
```

This file can be placed any where in the project, but the default docker-compose expects the file at `./config/db.env`.

## API Connectionstring Configuration
*Note: [Initialize dotnet user secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=linux#enable-secret-storage) if you have never used dotnet secrets.*

Create [user sceret](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=linux#set-a-secret) for accessing the connectionstring established in the `db.env`.
```
dotnet user-secrets set ConnectionStrings.docker-app "Server=db-container;Port=db-port;Database=database-name;Uid=basic-user;Pwd=basic-user-password"
```

## Deploying default containers
The default VS Code task executes the following:
```
docker compose up --build --force-recreate --detach
```