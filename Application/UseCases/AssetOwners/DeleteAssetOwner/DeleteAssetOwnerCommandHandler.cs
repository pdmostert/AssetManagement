using Application.Contracts.Persistence;
using MediatR;

namespace Application.UseCases.AssetOwners.DeleteAssetOwner;

/// <summary>
/// Command handler for deleting an asset owner.
/// </summary>
public class DeleteAssetOwnerCommandHandler : IRequestHandler<DeleteAssetOwnerCommand, Unit>
{
    private readonly IAssetOwnerRepository _assetOwnerRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteAssetOwnerCommandHandler"/> class.
    /// </summary>
    /// <param name="assetOwnerRepository">The asset owner repository.</param>
    public DeleteAssetOwnerCommandHandler(IAssetOwnerRepository assetOwnerRepository)
    {
        _assetOwnerRepository = assetOwnerRepository;
    }

    /// <summary>
    /// Handles the delete asset owner command.
    /// </summary>
    /// <param name="request">The delete asset owner command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous delete operation.</returns>
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
