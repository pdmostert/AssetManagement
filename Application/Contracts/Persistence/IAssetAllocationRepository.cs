using Application.DTOs;

namespace Application.Contracts.Persistence;
public interface IAssetAllocationRepository
{
    Task AllocateAssetToOwner(Guid assetId, Guid ownerId);

    Task<List<AssetSummaryDTO>> GetAssetSummary();
}
