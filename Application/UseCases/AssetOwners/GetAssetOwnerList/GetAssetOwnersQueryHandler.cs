using Application.Contracts.Persistence;
using Domain;
using MediatR;

namespace Application.UseCases.AssetOwners.GetAssetOwnerList;
internal class GetAssetOwnersQueryHandler : IRequestHandler<GetAssetOwnersQuery, List<AssetOwner>>
{
    private readonly IAssetOwnerRepository _assetOwnerRepository;

    public GetAssetOwnersQueryHandler(IAssetOwnerRepository assetOwnerRepository)
    {
        _assetOwnerRepository = assetOwnerRepository;
    }

    public async Task<List<AssetOwner>> Handle(GetAssetOwnersQuery request, CancellationToken cancellationToken)
    {
        return await _assetOwnerRepository.ListAll();
    }
}
