using Application.Contracts.Persistence;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.AssetAllocations.GetAssetAllocationByAsset;
internal class GetAssetAllocationByAssetQueryHandler : IRequestHandler<GetAssetAllocationByAssetQuery, List<AssetAllocationDto>>
{
    private readonly IAssetAllocationRepository _assetAllocationRepository;
    private readonly IAssetOwnerRepository _assetOwnerRepository;
    private readonly IAssetRepository _assetRepository;

    public GetAssetAllocationByAssetQueryHandler(
        IAssetAllocationRepository assetAllocationRepository,
        IAssetOwnerRepository assetOwnerRepository,
        IAssetRepository assetRepository)
    {
        _assetAllocationRepository = assetAllocationRepository;
        _assetOwnerRepository = assetOwnerRepository;
        _assetRepository = assetRepository;
    }

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
        
        return assetAllocationDtos;

    }
}
