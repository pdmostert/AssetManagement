using Application.Contracts.Persistence;
using MediatR;

namespace Application.UseCases.AssetOwners.DeleteAssetOwner;
public class DeleteAssetOwnerCommandHandler : IRequestHandler<DeleteAssetOwnerCommand, Unit>
{
    private readonly IAssetOwnerRepository _assetOwnerRepository;

    public DeleteAssetOwnerCommandHandler(IAssetOwnerRepository assetOwnerRepository)
    {
        _assetOwnerRepository = assetOwnerRepository;
    }

    public async Task<Unit> Handle(DeleteAssetOwnerCommand request, CancellationToken cancellationToken)
    {
        var assetOwner = await _assetOwnerRepository.GetById(request.AssetOwnerId);
        if (assetOwner == null)
        {
            throw new Exception("Asset Owner not found");
        }
        await _assetOwnerRepository.Delete(assetOwner);
        return await Unit.Task;
    }
}