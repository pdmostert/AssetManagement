WITH LatestAllocations AS (
    SELECT
        AssetId,
        AssetOwnerId,
        AllocationDate,
        ROW_NUMBER() OVER (PARTITION BY AssetID ORDER BY AllocationDate DESC) AS rn
    FROM AssetAllocation
)
SELECT
    ao.FullName,
    COUNT(la.AssetID) AS AssetCount
FROM
    AssetOwner ao
INNER JOIN
    (SELECT AssetId, AssetOwnerId, AllocationDate
     FROM LatestAllocations
     WHERE rn = 1) la
ON
    ao.Id = la.AssetOwnerId
GROUP BY
    ao.Id,
    ao.FullName
ORDER BY
    AssetCount DESC;
