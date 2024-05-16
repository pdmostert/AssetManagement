using Application.Contracts.Persistence;
using MediatR;

namespace Application.UseCases.AssetOwners.UpdateAssetowner;

internal class UpdateAssetOwnerCommandHandler : IRequestHandler<UpdateAssetOwnerCommand, Unit>
{
    private readonly IAssetOwnerRepository _assetOwnerRepository;

    public UpdateAssetOwnerCommandHandler(IAssetOwnerRepository assetOwnerRepository)
    {
        _assetOwnerRepository = assetOwnerRepository;
    }

    public async Task<Unit> Handle(UpdateAssetOwnerCommand request, CancellationToken cancellationToken)
    {
        var assetOwner = await _assetOwnerRepository.GetById(request.AssetOwnerId);
        if (assetOwner == null)
        {
            throw new Exception("Asset Owner not found");
        }

        assetOwner.FullName = request.FullName;
        assetOwner.Email = request.Email;
        assetOwner.PhoneNumber = request.PhoneNumber;
        assetOwner.Department = request.Department;

        await _assetOwnerRepository.Update(assetOwner);

        return Unit.Value;
    }
}
