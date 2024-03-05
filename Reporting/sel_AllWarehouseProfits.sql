SELECT 
    W.Name,
    SUM(D.TotalPrice) AS [Total Delivery Revenue],
    SUM(D.UnitCount) AS [Total Unit Count],
    SUM(D.TotalPrice) / SUM(D.UnitCount) AS [Average Revenue Per Unit]
FROM 
    Warehouses W
JOIN
    Deliveries D ON W.WarehouseId = D.SourceWarehouseId
GROUP BY 
    W.Name
ORDER BY 
    [Total Delivery Revenue] DESC;