using Application.Contracts.Persistence;
using Domain;
using MediatR;

namespace Application.UseCases.AssetOwners.GetAssetOwnerList;

/// <summary>
/// Handles the query to get a list of asset owners.
/// </summary>
internal class GetAssetOwnersQueryHandler : IRequestHandler<GetAssetOwnersQuery, List<AssetOwner>>
{
    private readonly IAssetOwnerRepository _assetOwnerRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAssetOwnersQueryHandler"/> class.
    /// </summary>
    /// <param name="assetOwnerRepository">The asset owner repository.</param>
    public GetAssetOwnersQueryHandler(IAssetOwnerRepository assetOwnerRepository)
    {
        _assetOwnerRepository = assetOwnerRepository;
    }

    /// <summary>
    /// Handles the get asset owners query.
    /// </summary>
    /// <param name="request">The get asset owners query.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of asset owners.</returns>
    public async Task<List<AssetOwner>> Handle(GetAssetOwnersQuery request, CancellationToken cancellationToken)
    {
        return await _assetOwnerRepository.ListAll();
    }
}
