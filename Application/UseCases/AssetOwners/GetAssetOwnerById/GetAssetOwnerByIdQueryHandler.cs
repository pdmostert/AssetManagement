using Application.Contracts.Persistence;
using Domain;
using MediatR;

namespace Application.UseCases.AssetOwners.GetAssetOwnerById;
internal class GetAssetOwnerByIdQueryHandler : IRequestHandler<GetAssetOwnerByIdQuery, AssetOwner>
{
    private readonly IAssetOwnerRepository _assetOwnerRepository;

    public GetAssetOwnerByIdQueryHandler(IAssetOwnerRepository assetOwnerRepository)
    {
        _assetOwnerRepository = assetOwnerRepository;
    }

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
