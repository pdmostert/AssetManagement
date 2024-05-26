using Domain;

namespace Application.DTOs;
public class AssetAllocationDto
{
    public Guid AssetId { get; set; }
    public Guid AssetOwnerId { get; set; }
    public DateTime AllocationDate { get; set; }
    public Asset Asset { get; set; }
    public AssetOwner AssetOwner { get; set; }

}
