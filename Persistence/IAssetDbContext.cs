using System.Data;

namespace Persistence;
internal interface IAssetDbContext
{
    IDbConnection CreateConnection(string connectionString = "AssetManager");
}