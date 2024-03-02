
# Entity Framework Core - Script-Migration Command

## Overview
The `Script-Migration` command in Entity Framework Core is a powerful tool for generating SQL scripts from migrations. This is particularly useful for generating a script that can be reviewed for accuracy, modified if necessary, and executed against a database, especially in production environments or where direct migration execution is not feasible or desired.

## Usefulness
- **Review Changes**: Allows reviewing the SQL script for potential issues or optimizations before applying changes to the database.
- **Manual Control Over Database Updates**: Provides control over when and how database updates are applied, particularly in environments with strict deployment processes.
- **Version Control**: SQL scripts generated can be version-controlled, providing a history of database changes.
- **Deployment**: Facilitates the deployment of database changes in scenarios where direct access to the database via `Update-Database` or `dotnet ef database update` is not available or preferred.

## Scripting Migrations

### Prerequisites
Ensure you have the .NET Entity Framework Core tools installed (`dotnet-ef`). If not, you can install them globally using:
```sh
dotnet tool install --global dotnet-ef
```

### Generating a SQL Script from All Migrations
To generate a SQL script from all migrations in the `PharmacyApi.Infrastructure` project, while using `PharmacyApi.WebApi` as the startup project, run the following command from the solution root directory:

```sh
dotnet ef migrations script --project ../PharmacyApi.Infrastructure/PharmacyApi.Infrastructure.csproj --startup-project ./PharmacyApi.WebApi.csproj --output ../PharmacyApi.Infrastructure/Migrations/Script.sql
```

### Generating a SQL Script for a Specific Range of Migrations
If you need to generate a script for a specific range of migrations, use:

```sh
dotnet ef migrations script FromMigration ToMigration --project ../PharmacyApi.Infrastructure/PharmacyApi.Infrastructure.csproj --startup-project ./PharmacyApi.WebApi.csproj --output ../PharmacyApi.Infrastructure/Migrations/RangeScript.sql
```

Replace `FromMigration` and `ToMigration` with the names of the migrations for which you want to generate the script. Use `0` for `FromMigration` to script from the beginning.

## Additional Notes
- The `--project` option specifies the EF Core project that contains your DbContext and migrations.
- The `--startup-project` option specifies the project that EF Core should use to run the application, necessary for finding the application's configuration and `DbContext`.
- The `--output` option determines where the generated SQL script will be saved.

Keep this file within the PharmacyApi solution for easy reference on managing EF Core migrations.
