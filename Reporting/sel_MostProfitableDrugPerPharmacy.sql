WITH RANKEDDRUGSALES AS ( 
    SELECT
        D.Name AS [Drug Sold],
        Phr.Name AS [Pharmacy Name],
        SUM(PS.UnitCount) AS [Drug Unit Sold],
        SUM(PS.TotalPrice) AS [Sale Amount],
        RANK() OVER(PARTITION BY Phr.Name ORDER BY SUM(PS.TotalPrice) DESC) [Ranking]
    FROM 
        PharmacySales PS
    JOIN
        Drug D ON PS.DrugId = D.DrugId
    JOIN 
        Pharmacists Pht ON PS.PharmacistId = Pht.PharmacistId
    JOIN 
        Pharmacies Phr ON Pht.PharmacyId = Phr.PharmacyId
    GROUP BY
        Phr.Name, D.Name
)
SELECT 
    * 
FROM 
    RANKEDDRUGSALES
WHERE 
    [Ranking] = 1
ORDER BY
    [Sale Amount] DESC