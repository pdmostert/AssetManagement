using System.Data;

namespace Persistence;

/// <summary>
/// Represents the interface for the asset database context.
/// </summary>
internal interface IAssetDbContext
{
    /// <summary>
    /// Creates a new database connection.
    /// </summary>
    /// <param name="connectionString">The connection string to use. Default value is "AssetManager".</param>
    /// <returns>A new instance of <see cref="IDbConnection"/>.</returns>
    IDbConnection CreateConnection(string connectionString = "AssetManager");
}
