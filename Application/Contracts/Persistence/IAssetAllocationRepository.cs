using Application.DTOs;
using Domain;

namespace Application.Contracts.Persistence;
public interface IAssetAllocationRepository
{
    Task AllocateAssetToOwner(Guid assetId, Guid ownerId);

    Task<List<AssetSummaryDTO>> GetAssetSummary();
    Task<List<AssetAllocation>> GetAll();
}
