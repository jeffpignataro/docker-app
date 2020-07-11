# Dockerized Dotnet Core Application

## Prerequisites
Make sure to install docker-io and docker-compose before proceeding with the application.

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

Create [user sceret](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=linux#set-a-secret) for accessing the connectionstring established in the `db.env`. This command should be run from the /api folder.
```
dotnet user-secrets set ConnectionStrings.docker-app "Server=db-container;Port=db-port;Database=database-name;Uid=basic-user;Pwd=basic-user-password"
```

### *Optional* Enable EF Migrations
This is not required as there are many other options for database management. But [migrations](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-3.1) are a stanard functionality in EF.
```
dotnet ef migrations add InitialCreate
```

## Connectionstring Reference
Add DBContext and connectionstring information to `Startup.cs`
```
services.AddDbContext<DockerAppContext>(options =>
    options.UseMySQL(Configuration["ConnectionStrings.docker-app"]));
```

## API Controller Scaffolding
Install the [aspnet-codegenerator](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator?view=aspnetcore-3.1) tool in order to quickly scaffold controllers based off the EF context.
```
aspnet-codegenerator controller -name UserController -api -m User -dc DockerAppContext --relativeFolderPath Controllers/v1
```

## Deploying default containers
The default VS Code task executes the following:
```
docker compose up --build --force-recreate --detach
```