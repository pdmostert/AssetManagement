using Application.Contracts.Persistence;
using Domain;
using MediatR;

namespace Application.UseCases.AssetOwners.GetAssetOwnerById;

/// <summary>
/// Query handler for retrieving an asset owner by ID.
/// </summary>
internal class GetAssetOwnerByIdQueryHandler : IRequestHandler<GetAssetOwnerByIdQuery, AssetOwner>
{
    private readonly IAssetOwnerRepository _assetOwnerRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAssetOwnerByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="assetOwnerRepository">The asset owner repository.</param>
    public GetAssetOwnerByIdQueryHandler(IAssetOwnerRepository assetOwnerRepository)
    {
        _assetOwnerRepository = assetOwnerRepository;
    }

    /// <summary>
    /// Handles the asset owner retrieval by ID.
    /// </summary>
    /// <param name="request">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The retrieved asset owner.</returns>
    public async Task<AssetOwner> Handle(GetAssetOwnerByIdQuery request, CancellationToken cancellationToken)
    {
        var assetOwner = await _assetOwnerRepository.GetById(request.AssetOwnerId);
        if (assetOwner == null)
        {
            throw new Exception("Asset Owner not found");
        }
        return assetOwner;
    }
}
