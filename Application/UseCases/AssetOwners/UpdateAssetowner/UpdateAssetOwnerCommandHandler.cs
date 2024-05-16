using Application.Contracts.Persistence;
using MediatR;

namespace Application.UseCases.AssetOwners.UpdateAssetowner;

/// <summary>
/// Handles the command to update an asset owner.
/// </summary>
internal class UpdateAssetOwnerCommandHandler : IRequestHandler<UpdateAssetOwnerCommand, Unit>
{
    private readonly IAssetOwnerRepository _assetOwnerRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateAssetOwnerCommandHandler"/> class.
    /// </summary>
    /// <param name="assetOwnerRepository">The asset owner repository.</param>
    public UpdateAssetOwnerCommandHandler(IAssetOwnerRepository assetOwnerRepository)
    {
        _assetOwnerRepository = assetOwnerRepository;
    }

    /// <summary>
    /// Handles the update asset owner command.
    /// </summary>
    /// <param name="request">The update asset owner command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
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
