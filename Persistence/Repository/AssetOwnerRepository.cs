using Application.Contracts.Persistence;
using Dapper;
using Domain;
using System.Data;

namespace Persistence.Repository;

/// <summary>
/// Represents the repository for managing asset owners.
/// </summary>
internal class AssetOwnerRepository : IAssetOwnerRepository
{
    private readonly IDbConnection _dbConnection;

    /// <summary>
    /// Initializes a new instance of the <see cref="AssetOwnerRepository"/> class.
    /// </summary>
    /// <param name="assetDbContext">The asset database context.</param>
    public AssetOwnerRepository(IAssetDbContext assetDbContext)
    {
        _dbConnection = assetDbContext.CreateConnection();
    }

    /// <inheritdoc/>
    public async Task Add(AssetOwner entity)
    {
        string sql = @"INSERT INTO AssetOwner
                            (Id, FullName, Email, PhoneNumber, Department)
                            VALUES (@Id,@FullName,@Email,@PhoneNumber,@Department)";

        await _dbConnection.ExecuteAsync(sql, entity);
    }

    /// <inheritdoc/>
    public async Task Delete(AssetOwner entity)
    {
        string sql = @"DELETE FROM AssetOwner WHERE  (Id = @Id)";

        await _dbConnection.ExecuteAsync(sql, entity);
    }

    /// <inheritdoc/>
    public async Task<AssetOwner> GetById(Guid id)
    {
        string sql = @"SELECT Id, FullName, Email, PhoneNumber, Department
                            FROM AssetOwner
                            WHERE (Id = @Id)";

        var result = await _dbConnection.QueryFirstOrDefaultAsync<AssetOwner>(sql, new { Id = id });
        return result;
    }

    /// <inheritdoc/>
    public async Task<List<AssetOwner>> ListAll()
    {
        string sql = @"SELECT Id, FullName, Email, PhoneNumber, Department FROM AssetOwner";

        var result = await _dbConnection.QueryAsync<AssetOwner>(sql);
        return result.ToList();
    }

    /// <inheritdoc/>
    public async Task Update(AssetOwner entity)
    {
        string sql = @"UPDATE AssetOwner
                        SET FullName = @FullName, Email = @Email, PhoneNumber = @PhoneNumber, Department = @Department WHERE Id = @Id";

        await _dbConnection.ExecuteAsync(sql, entity);
    }
}
