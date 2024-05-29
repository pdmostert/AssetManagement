using Application.Contracts.Persistence;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.AssetAllocations.GetAssetAllocationByAsset;

/// <summary>
/// Handles the query to get asset allocations by asset.
/// </summary>
internal class GetAssetAllocationByAssetQueryHandler : IRequestHandler<GetAssetAllocationByAssetQuery, List<AssetAllocationDto>>
{
    private readonly IAssetAllocationRepository _assetAllocationRepository;
    private readonly IAssetOwnerRepository _assetOwnerRepository;
    private readonly IAssetRepository _assetRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAssetAllocationByAssetQueryHandler"/> class.
    /// </summary>
    /// <param name="assetAllocationRepository">The asset allocation repository.</param>
    /// <param name="assetOwnerRepository">The asset owner repository.</param>
    /// <param name="assetRepository">The asset repository.</param>
    public GetAssetAllocationByAssetQueryHandler(
        IAssetAllocationRepository assetAllocationRepository,
        IAssetOwnerRepository assetOwnerRepository,
        IAssetRepository assetRepository)
    {
        _assetAllocationRepository = assetAllocationRepository;
        _assetOwnerRepository = assetOwnerRepository;
        _assetRepository = assetRepository;
    }

    /// <summary>
    /// Handles the asset allocation query and returns a list of asset allocation DTOs.
    /// </summary>
    /// <param name="request">The asset allocation query.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of asset allocation DTOs.</returns>
    public async Task<List<AssetAllocationDto>> Handle(GetAssetAllocationByAssetQuery request, CancellationToken cancellationToken)
    {
        var allocationList = await _assetAllocationRepository.GetAll();
        List<AssetAllocationDto> assetAllocationDtos = new List<AssetAllocationDto>();
        foreach (var item in allocationList)
        {
            var asset = await _assetRepository.GetById(item.AssetId);
            var owner = await _assetOwnerRepository.GetById(item.AssetOwnerId);
            assetAllocationDtos.Add(new AssetAllocationDto
            {
                AssetId = item.AssetId,
                AssetOwnerId = item.AssetOwnerId,
                AllocationDate = item.AllocationDate,
                Asset = asset,
                AssetOwner = owner
            });
        }
        assetAllocationDtos.Sort((x, y) => y.AllocationDate.CompareTo(x.AllocationDate));

        return assetAllocationDtos;
    }
}
