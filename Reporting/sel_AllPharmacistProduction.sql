SELECT 
    Pht.FullName AS [Pharmacist Name],
    Phr.Name AS [Pharmacy Name],
    D.Name AS [Drug Sold],
    SUM(PS.UnitCount) AS [Drug Unit Sold],
    SUM(PS.TotalPrice) AS [Sale Amount],
    RANK() OVER(ORDER BY SUM(PS.TotalPrice) DESC) [Ranking]
FROM 
    PharmacySales PS
JOIN
    Pharmacists Pht ON PS.PharmacistId = Pht.PharmacistId
JOIN
    Drug D ON PS.DrugId = D.DrugId
JOIN 
    Pharmacies Phr ON Pht.PharmacyId = Phr.PharmacyId
GROUP BY
    Pht.FullName, Phr.Name, D.Name
ORDER BY 
    [Sale Amount] DESC;