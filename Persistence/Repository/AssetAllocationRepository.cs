using Application.Contracts.Persistence;
using Application.DTOs;
using Dapper;
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

    /// <summary>
    /// Gets the asset summary.
    /// </summary>
    /// <returns>A list of asset summaries.</returns>
    public async Task<List<AssetSummaryDTO>> GetAssetSummary()
    {
        string sql = @"SELECT AssetOwner.FullName, COUNT(Assets.Id) AS AssetCount
                           FROM AssetOwner
                           INNER JOIN AssetAllocation ON AssetOwner.Id = AssetAllocation.AssetOwnerId
                           INNER JOIN Assets ON AssetAllocation.AssetId = Assets.Id
                           GROUP BY AssetOwner.FullName";
        var result = await _dbConnection.QueryAsync<AssetSummaryDTO>(sql);
        return result.ToList();
    }
}
