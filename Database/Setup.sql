BEGIN TRANSACTION;
GO

CREATE TABLE [Pharmacists] (
    [PharmacistId]  BIGINT          NOT NULL IDENTITY,
    [PharmacyId]    BIGINT          NOT NULL,
    [FullName]      NVARCHAR(255)   NOT NULL,
    [Age]           INT             NOT NULL,
    [StartDate]     DATETIME2       NULL,
    [EndDate]       DATETIME2       NULL,
    CONSTRAINT [PK_Pharmacists] PRIMARY KEY ([PharmacistId]),
    CONSTRAINT [FK_Pharmacies_Pharmacists]  FOREIGN KEY ([PharmacyId]) REFERENCES [Pharmacies]([PharmacyId])
);

CREATE TABLE [Warehouses] (
    [WarehouseId]   BIGINT          NOT NULL IDENTITY,
    [Name]          NVARCHAR(255)   NOT NULL,
    [Address]       NVARCHAR(255)   NOT NULL,
    CONSTRAINT [PK_Warehouses] PRIMARY KEY ([WarehouseId])
);

CREATE TABLE [Drug] (
    [DrugId]        BIGINT          NOT NULL IDENTITY,
    [Name]          NVARCHAR(255)   NOT NULL,
    [Description]   NVARCHAR(255)   NOT NULL,
    CONSTRAINT [PK_Drug] PRIMARY KEY ([DrugId])
);

CREATE TABLE [Deliveries] (
    [DeliveryId]            BIGINT          NOT NULL IDENTITY,
    [SourceWarehouseId]     BIGINT          NOT NULL,
    [OrderingPharmacyId]    BIGINT          NOT NULL,
    [DrugId]                BIGINT          NOT NULL,
    [UnitCount]             INT             NOT NULL,
    [UnitPrice]             MONEY           NOT NULL,
    [TotalPrice]            AS (UnitCount * UnitPrice),
    [DeliveryDate]          DATETIME2       NOT NULL,
    CONSTRAINT [PK_Deliveries] PRIMARY KEY ([DeliveryId]),
    CONSTRAINT [FK_Deliveries_Warehouses] FOREIGN KEY ([SourceWarehouseId]) REFERENCES [Warehouses]([WarehouseId]),
    CONSTRAINT [FK_Deliveries_Pharmacies] FOREIGN KEY ([OrderingPharmacyId]) REFERENCES [Pharmacies]([PharmacyId]),
    CONSTRAINT [FK_Deliveries_Drug] FOREIGN KEY ([DrugId]) REFERENCES [Drug]([DrugId])
);

CREATE TABLE [PharmacySales] (
    [PharmacySaleId]    BIGINT      NOT NULL IDENTITY,
    [PharmacistId]      BIGINT      NOT NULL,
    [DrugId]            BIGINT      NOT NULL,
    [SaleDate]          DATETIME2   NOT NULL,
    CONSTRAINT [PK_PharmacySales] PRIMARY KEY ([PharmacySaleId]),
    CONSTRAINT [FK_PharmacySales_Pharmacists] FOREIGN KEY ([PharmacistId]) REFERENCES [Pharmacists]([PharmacistId]),
    CONSTRAINT [FK_PharmacySales_Drug] FOREIGN KEY ([DrugId]) REFERENCES [Drug]([DrugId])
);

-- Inserting 1 pharmacist for each pharmacy
INSERT INTO Pharmacists (PharmacyId, FullName, Age, StartDate)
VALUES
(1, 'John Doe', 40, '2023-01-01'),
(2, 'Jane Smith', 35, '2023-01-01'),
(3, 'Emily Carter', 29, '2023-01-01'),
(4, 'Michael Brown', 45, '2023-01-01'),
(5, 'Jessica Davis', 31, '2023-01-01'),
(1, 'Jose Ricardo', 24, '2023-01-01'),
(2, 'Kris Li', 30, '2023-01-01'),
(3, 'Maya Mohammad', 41, '2023-01-01'),
(4, 'JeeHyun Han', 28, '2023-01-01'),
(5, 'Kristen Lee', 25, '2023-01-01');

-- Inserting 3 warehouses
INSERT INTO Warehouses (Name, Address)
VALUES
('Central Warehouse', '123 Central St'),
('Eastside Storage', '456 Eastside Ave'),
('Westend Depot', '789 Westend Rd');

-- Inserting 10 drugs
INSERT INTO Drug (Name, Description)
VALUES
('Ibuprofen', 'A nonsteroidal anti-inflammatory drug used for treating pain, fever, and inflammation.'),
('Acetaminophen', 'An analgesic and antipyretic used for pain relief and to reduce fever.'),
('Amoxicillin', 'An antibiotic used to treat a number of bacterial infections.'),
('Lisinopril', 'An ACE inhibitor used to treat high blood pressure and heart failure.'),
('Atorvastatin', 'A statin used to prevent cardiovascular disease and treat abnormal lipid levels.'),
('Metformin', 'An oral diabetes medicine that helps control blood sugar levels.'),
('Amlodipine', 'A calcium channel blocker used to treat high blood pressure and coronary artery disease.'),
('Albuterol', 'A medication that opens up the medium and large airways in the lungs.'),
('Hydrochlorothiazide', 'A diuretic medication often used to treat high blood pressure and swelling.'),
('Gabapentin', 'A medication used to treat partial seizures and neuropathic pain.');

-- Inserting 20 Deliveries within a two month period
DECLARE @d INT = 1;
WHILE @d <= 20
BEGIN
    INSERT INTO Deliveries (SourceWarehouseId, OrderingPharmacyId, DrugId, UnitCount, UnitPrice, DeliveryDate)
    VALUES (
        (@d % 3) + 1, -- SourceWarehouseId cycling through 1, 2, 3
        (@d % 5) + 1, -- OrderingPharmacyId cycling through 1 to 5
        (@d % 10) + 1, -- DrugId cycling through 1 to 10
        RAND() * 100, -- UnitCount random up to 100
        RAND() * 100, -- UnitPrice random up to $100
        DATEADD(day, (@d * 3) % 60, '2024-01-01') -- DeliveryDate spread over 2 months
    );
    SET @d = @d + 1;
END;

-- Inserting 40 PharmacySales within a two month period
DECLARE @d INT = 1;
WHILE @d <= 40
BEGIN
    INSERT INTO PharmacySales (PharmacistId, DrugId, SaleDate)
    VALUES (
        FLOOR(RAND() * 10) + 1, -- PharmacistId random up to 10
        FLOOR(RAND() * 10) + 1, -- DrugId random up to 10
        DATEADD(day, (@d * 3) % 90, '2024-02-01') -- SaleDate spread over 3 months
    );
    SET @d = @d + 1;
END;

TRUNCATE TABLE PharmacySales

COMMIT TRANSACTION;