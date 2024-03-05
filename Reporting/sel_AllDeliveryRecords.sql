SELECT 
    W.Name AS [Warehouse FROM],
    P.Name AS [Pharmacy TO] 
FROM 
    Deliveries D 
JOIN 
    Warehouses W ON D.SourceWarehouseId = W.WarehouseId
JOIN 
    Pharmacies P ON D.OrderingPharmacyId = P.PharmacyId;