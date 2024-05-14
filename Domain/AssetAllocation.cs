using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public class AssetAllocation
{
    public AssetAllocation()
    {
        
    }

    public AssetAllocation(Guid assetId, Guid assetOwnerId)
    {
        AssetId = assetId;
        AssetOwnerId = assetOwnerId;
        AllocationDate = DateTime.Now;
    }

    public Guid AssetId { get; set; }
    public Guid AssetOwnerId { get; set; }
    public DateTime AllocationDate { get; set; }
}
