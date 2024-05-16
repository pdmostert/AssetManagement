using Application.Contracts.Persistence;
using MediatR;

namespace Application.UseCases.AssetAllocations.AllocateAssetToOwner;

internal class AllocateAssetToOwnerCommandHandler : IRequestHandler<AllocateAssetToOwnerCommand, Unit>
{
    private readonly IAssetAllocationRepository _assetAllocationRepository;
    private readonly IAssetOwnerRepository _assetOwnerRepository;
    private readonly IAssetRepository _assetRepository;

    public AllocateAssetToOwnerCommandHandler(IAssetAllocationRepository assetAllocationRepository, IAssetOwnerRepository assetOwnerRepository, IAssetRepository assetRepository)
    {
        _assetAllocationRepository = assetAllocationRepository;
        _assetOwnerRepository = assetOwnerRepository;
        _assetRepository = assetRepository;
    }

    public async Task<Unit> Handle(AllocateAssetToOwnerCommand request, CancellationToken cancellationToken)
    {
        var assetOwner = await _assetOwnerRepository.GetById(request.AssetOwnerId);
        var asset = await _assetRepository.GetById(request.AssetId);
        if (asset == null)
        {
            throw new Exception("Asset not found");
        }
        if (assetOwner == null)
        {
            throw new Exception("Asset Owner not found");
        }
        await _assetAllocationRepository.AllocateAssetToOwner(request.AssetId, request.AssetOwnerId);
        return Unit.Value;

    }
}

