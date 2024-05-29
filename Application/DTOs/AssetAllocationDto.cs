using Domain;

namespace Application.DTOs;
// Dto to represent the Asset Allocation and its properties
public class AssetAllocationDto
{
    public Guid AssetId { get; set; }
    public Guid AssetOwnerId { get; set; }
    public DateTime AllocationDate { get; set; }
    public Asset Asset { get; set; }
    public AssetOwner AssetOwner { get; set; }

}
