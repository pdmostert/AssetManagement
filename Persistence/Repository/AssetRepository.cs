using Application.Contracts.Persistence;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository;
internal class AssetRepository : GenericRepository<Asset>, IAssetRepository
{
    public AssetRepository(IAssetDbContext<Asset> assetDbContext, string assetFileName = "Assets.json") : base(assetDbContext, assetFileName)
    {

    }

}
