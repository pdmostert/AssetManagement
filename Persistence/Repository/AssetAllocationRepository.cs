using Application.Contracts.Persistence;
using Application.DTOs;
using Dapper;
using Domain;
using System.Data;

namespace Persistence.Repository;

/// <summary>
/// Represents the repository for asset allocation.
/// </summary>
internal class AssetAllocationRepository : IAssetAllocationRepository
{
    private readonly IDbConnection _dbConnection;

    /// <summary>
    /// Initializes a new instance of the <see cref="AssetAllocationRepository"/> class.
    /// </summary>
    /// <param name="assetDbContext">The asset database context.</param>
    public AssetAllocationRepository(IAssetDbContext assetDbContext)
    {
        _dbConnection = assetDbContext.CreateConnection();
    }

    /// <summary>
    /// Allocates an asset to an owner.
    /// </summary>
    /// <param name="assetId">The ID of the asset.</param>
    /// <param name="ownerId">The ID of the owner.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AllocateAssetToOwner(Guid assetId, Guid ownerId)
    {
        string sql = @"INSERT INTO AssetAllocation
                          (AssetId, AssetOwnerId, AllocationDate)
                          VALUES (@AssetId, @AssetOwnerId, @AllocationDate)";
        await _dbConnection.ExecuteAsync(sql, new { AssetId = assetId, AssetOwnerId = ownerId, AllocationDate = DateTime.Now });
    }

    public async  Task<List<AssetAllocation>> GetAll()
    {
        string sql = @"SELECT [AssetId],[AssetOwnerId],[AllocationDate] 
                    FROM [AssetManagementDB].[dbo].[AssetAllocation]";
        var result = await _dbConnection.QueryAsync<AssetAllocation>(sql);
        return result.ToList();
    }

    /// <summary>
    /// Gets the asset summary.
    /// </summary>
    /// <returns>A list of asset summaries.</returns>
    public async Task<List<AssetSummaryDTO>> GetAssetSummary()
    {
        string sql = @"WITH LatestAllocations AS (
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
                        AssetCount DESC;";
        var result = await _dbConnection.QueryAsync<AssetSummaryDTO>(sql);
        return result.ToList();
    }
}
