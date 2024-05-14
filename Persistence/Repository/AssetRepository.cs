using Application.Contracts.Persistence;
using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Persistence.Repository;

/// <summary>
/// Represents a repository for managing assets.
/// </summary>
internal class AssetRepository : IAssetRepository
{
    private readonly IDbConnection _dbConnection;

    public AssetRepository(IAssetDbContext assetDbContext)
    {
        _dbConnection = assetDbContext.CreateConnection();
    }

    public async Task Add(Asset entity)
    {
        string sql = @"INSERT INTO Assets (Id, Name, Description, Make, Model, SerialNumber, Category, SubCategory, Type, Status)
                        VALUES (@Id,@Name,@Description,@Make,@Model,@SerialNumber,@Category,@SubCategory,@Type,@Status)";
        await _dbConnection.ExecuteAsync(sql, entity);
    }

    public async Task Delete(Asset entity)
    {
        string sql = @"DELETE FROM Assets WHERE (Id = @Id)";
        await _dbConnection.ExecuteAsync(sql, entity);
    }

    public async Task<Asset> GetById(Guid id)
    {
        string sql = @"SELECT Id, Name, Description, Make, Model, SerialNumber, Category, SubCategory, Type, Status
                        FROM     Assets
                        WHERE  (Id = @Id)";
        var result = await _dbConnection.QueryFirstOrDefaultAsync<Asset>(sql, new { Id = id });
        return result;
    }

    public async  Task<List<Asset>> ListAll()
    {
        string sql = @"SELECT Id, Name, Description, Make, Model, SerialNumber, Category, SubCategory, Type, Status
                    FROM Assets";
        var result = await _dbConnection.QueryAsync<Asset>(sql);
        return result.ToList();
    }

    public async Task Update(Asset entity)
    {
        string sql = @"UPDATE Assets
                        SET Name = @Name, Description = @Description, Make = @Make, Model = @Model,
                            SerialNumber = @SerialNumber, Category = @Category, SubCategory = @SubCategory,
                            Type = @Type, Status = @Status WHERE Id=@Id";
        await _dbConnection.ExecuteAsync(sql, entity);
    }
}
