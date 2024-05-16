using Application.Contracts.Persistence;
using Dapper;
using Domain;
using System.Data;

namespace Persistence.Repository;
internal class AssetOwnerRepository : IAssetOwnerRepository
{
    private readonly IDbConnection _dbConnection;

    public AssetOwnerRepository(IAssetDbContext assetDbContext)
    {
        _dbConnection = assetDbContext.CreateConnection();
    }

    public async Task Add(AssetOwner entity)
    {
        string sql = @"INSERT INTO AssetOwner
                        (Id, FullName, Email, PhoneNumber, Department)
                        VALUES (@Id,@FullName,@Email,@PhoneNumber,@Department)";

        await _dbConnection.ExecuteAsync(sql, entity);
    }

    public async Task Delete(AssetOwner entity)
    {
        string sql = @"DELETE FROM AssetOwner WHERE  (Id = @Id)";

        await _dbConnection.ExecuteAsync(sql, entity);
    }

    public async Task<AssetOwner> GetById(Guid id)
    {
        string sql = @"SELECT Id, FullName, Email, PhoneNumber, Department
                        FROM AssetOwner
                        WHERE (Id = @Id)";

        var result = await _dbConnection.QueryFirstOrDefaultAsync<AssetOwner>(sql, new { Id = id });
        return result;
    }

    public async Task<List<AssetOwner>> ListAll()
    {
        string sql = @"SELECT Id, FullName, Email, PhoneNumber, Department FROM AssetOwner";

        var result = await _dbConnection.QueryAsync<AssetOwner>(sql);
        return result.ToList();
    }

    public async Task Update(AssetOwner entity)
    {
        string sql = @"UPDATE AssetOwner
                    SET FullName = @FullName, Email = @Email, PhoneNumber = @PhoneNumber, Department = @Department";

        await _dbConnection.ExecuteAsync(sql, entity);
    }
}
