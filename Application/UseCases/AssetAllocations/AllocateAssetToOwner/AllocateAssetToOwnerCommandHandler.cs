using Application.Contracts.Persistence;
using MediatR;

namespace Application.UseCases.AssetAllocations.AllocateAssetToOwner;

/// <summary>
/// Handles the command to allocate an asset to an owner.
/// </summary>
internal class AllocateAssetToOwnerCommandHandler : IRequestHandler<AllocateAssetToOwnerCommand, Unit>
{
    private readonly IAssetAllocationRepository _assetAllocationRepository;
    private readonly IAssetOwnerRepository _assetOwnerRepository;
    private readonly IAssetRepository _assetRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="AllocateAssetToOwnerCommandHandler"/> class.
    /// </summary>
    /// <param name="assetAllocationRepository">The asset allocation repository.</param>
    /// <param name="assetOwnerRepository">The asset owner repository.</param>
    /// <param name="assetRepository">The asset repository.</param>
    public AllocateAssetToOwnerCommandHandler(IAssetAllocationRepository assetAllocationRepository, IAssetOwnerRepository assetOwnerRepository, IAssetRepository assetRepository)
    {
        _assetAllocationRepository = assetAllocationRepository;
        _assetOwnerRepository = assetOwnerRepository;
        _assetRepository = assetRepository;
    }

    /// <summary>
    /// Handles the allocation of an asset to an owner.
    /// </summary>
    /// <param name="request">The allocate asset to owner command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
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

