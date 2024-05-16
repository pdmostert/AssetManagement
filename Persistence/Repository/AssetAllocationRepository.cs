using Application.Contracts.Persistence;
using Application.DTOs;
using Dapper;
using System.Data;

namespace Persistence.Repository;
internal class AssetAllocationRepository : IAssetAllocationRepository
{
    private readonly IDbConnection _dbConnection;
    public AssetAllocationRepository(IAssetDbContext assetDbContext)
    {
        _dbConnection = assetDbContext.CreateConnection();
    }
    public async Task AllocateAssetToOwner(Guid assetId, Guid ownerId)
    {
        string sql = @"INSERT INTO AssetAllocation
                  (AssetId, AssetOwnerId, AllocationDate)
                    VALUES (@AssetId,@AssetOwnerId,@AllocationDate)";
        await _dbConnection.ExecuteAsync(sql, new { AssetId = assetId, AssetOwnerId = ownerId, AllocationDate = DateTime.Now });

    }

    public async Task<List<AssetSummaryDTO>> GetAssetSummary()
    {
        string sql = @"SELECT AssetOwner.FullName, COUNT(Assets.Id) AS AssetCount
                    FROM     AssetOwner INNER JOIN
                                      AssetAllocation ON AssetOwner.Id = AssetAllocation.AssetOwnerId INNER JOIN
                                      Assets ON AssetAllocation.AssetId = Assets.Id
                    GROUP BY AssetOwner.FullName";
        var result = await _dbConnection.QueryAsync<AssetSummaryDTO>(sql);
        return result.ToList();
    }
}
