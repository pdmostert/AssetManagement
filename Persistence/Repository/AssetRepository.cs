using Application.Contracts.Persistence;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository;

/// <summary>
/// Represents a repository for managing assets.
/// </summary>
internal class AssetRepository : GenericRepository<Asset>, IAssetRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AssetRepository"/> class.
    /// </summary>
    /// <param name="assetDbContext">The asset database context.</param>
    /// <param name="assetFileName">The asset file name.</param>
    public AssetRepository(IAssetDbContext<Asset> assetDbContext, string assetFileName = "Assets.json") : base(assetDbContext, assetFileName)
    {

    }
}
