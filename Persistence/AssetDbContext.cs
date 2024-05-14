using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

/// <summary>
/// Represents the asset database context.
/// </summary>
internal class AssetDbContext : IAssetDbContext
{
    private readonly IConfiguration _configuration;

    public AssetDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection(string connectionString = "AssetManager")
    {
        string? connection = _configuration.GetConnectionString(connectionString);
        return new SqlConnection(connection);
    }


}
