
# Migration Commands for EF Core

This document serves as a reference for running Entity Framework Core migration commands within the PharmacyApi.Infrastructure project.

## Setting Up for Migrations

Ensure that the dotnet-ef tool is installed globally on your machine. If not, install it using:

```sh
dotnet tool install --global dotnet-ef
```

## Running Migrations

Navigate to the root directory of your solution where the PharmacyApi.WebApi project is located. Use the following command to add a migration:

```sh
dotnet ef migrations add <MigrationName> --project ../PharmacyApi.Infrastructure/PharmacyApi.Infrastructure.csproj --startup-project ./PharmacyApi.WebApi.csproj
```

Replace `<MigrationName>` with the name you wish to give your migration.

## Updating the Database

After creating a migration, apply it to update the database using:

```sh
dotnet ef database update --project ../PharmacyApi.Infrastructure/PharmacyApi.Infrastructure.csproj --startup-project ./PharmacyApi.WebApi.csproj
```

## Reverting Migrations

To revert a migration, you can use the `database update` command with the name of the migration you want to roll back to:

```sh
dotnet ef database update <PreviousMigrationName> --project ../PharmacyApi.Infrastructure/PharmacyApi.Infrastructure.csproj --startup-project ./PharmacyApi.WebApi.csproj
```

If you want to revert all migrations and reset your database, you can use:

```sh
dotnet ef database update 0 --project ../PharmacyApi.Infrastructure/PharmacyApi.Infrastructure.csproj --startup-project ./PharmacyApi.WebApi.csproj
```

## Removing Migrations

If you need to remove the last migration (for instance, if you made a mistake), you can use:

```sh
dotnet ef migrations remove --project ../PharmacyApi.Infrastructure/PharmacyApi.Infrastructure.csproj --startup-project ./PharmacyApi.WebApi.csproj
```

Make sure you have not applied the migration to the database, or you will need to revert it first.

---

Keep this file within the PharmacyApi.Infrastructure project for future reference on managing EF Core migrations.
