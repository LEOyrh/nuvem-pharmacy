IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Pharmacies] (
    [PharmacyId] bigint NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Address] nvarchar(max) NOT NULL,
    [City] nvarchar(50) NOT NULL,
    [State] nvarchar(2) NOT NULL,
    [Zip] nvarchar(10) NOT NULL,
    [NumberOfFilledPrescriptions] int NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Pharmacies] PRIMARY KEY ([PharmacyId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240301081444_InitialCreate', N'7.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PharmacyId', N'Address', N'City', N'CreatedDate', N'Name', N'NumberOfFilledPrescriptions', N'State', N'UpdatedDate', N'Zip') AND [object_id] = OBJECT_ID(N'[Pharmacies]'))
    SET IDENTITY_INSERT [Pharmacies] ON;
INSERT INTO [Pharmacies] ([PharmacyId], [Address], [City], [CreatedDate], [Name], [NumberOfFilledPrescriptions], [State], [UpdatedDate], [Zip])
VALUES (CAST(1 AS bigint), N'150 E Stacy Rd Suite 2400', N'Allen', '2024-03-01T23:43:11.6477430-06:00', N'CVS Pharmacy', 0, N'TX', '2024-03-01T23:43:11.6477480-06:00', N'75002'),
(CAST(2 AS bigint), N'575 E Exchange Pkwy', N'Allen', '2024-03-01T23:43:11.6477480-06:00', N'H-E-B Pharmacy', 0, N'TX', '2024-03-01T23:43:11.6477480-06:00', N'75002'),
(CAST(3 AS bigint), N'730 W Exchange Pkwy', N'Allen', '2024-03-01T23:43:11.6477480-06:00', N'Walmart Pharmacy', 0, N'TX', '2024-03-01T23:43:11.6477480-06:00', N'75013'),
(CAST(4 AS bigint), N'500 E Stacy Rd', N'Allen', '2024-03-01T23:43:11.6477480-06:00', N'Walgreens Pharmacy', 0, N'TX', '2024-03-01T23:43:11.6477490-06:00', N'75002'),
(CAST(5 AS bigint), N'1210 N Greenville Ave', N'Allen', '2024-03-01T23:43:11.6477490-06:00', N'Kroger Pharmacy', 0, N'TX', '2024-03-01T23:43:11.6477490-06:00', N'75002');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'PharmacyId', N'Address', N'City', N'CreatedDate', N'Name', N'NumberOfFilledPrescriptions', N'State', N'UpdatedDate', N'Zip') AND [object_id] = OBJECT_ID(N'[Pharmacies]'))
    SET IDENTITY_INSERT [Pharmacies] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240302054311_SeededDB', N'7.0.16');
GO

COMMIT;
GO

