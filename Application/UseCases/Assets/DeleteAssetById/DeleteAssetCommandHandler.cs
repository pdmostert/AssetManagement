using Application.Contracts.Persistence;
using MediatR;

namespace Application.UseCases.Assets.DeleteAssetById;

/// <summary>
/// Handles the command to delete an asset by its ID.
/// </summary>
internal class DeleteAssetCommandHandler : IRequestHandler<DeleteAssetCommand, Unit>
{
    private readonly IAssetRepository _assetRepository;

    public DeleteAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    /// <summary>
    /// Handles the delete asset command.
    /// </summary>
    /// <param name="request">The delete asset command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<Unit> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
    {
        var assetToDelete = _assetRepository.GetById(request.AssetId).Result;

        _assetRepository.Delete(assetToDelete);
        return Unit.Task;
    }
}
