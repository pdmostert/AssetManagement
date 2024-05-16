using Application.Contracts.Persistence;
using Domain;
using MediatR;

namespace Application.UseCases.Assets.UpdateAsset;

internal class UpdateAssetCommandHandler : IRequestHandler<UpdateAssetCommand, Unit>
{
    private readonly IAssetRepository _assetRepository;

    public UpdateAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    /// <summary>
    /// Handles the update asset command.
    /// </summary>
    /// <param name="request">The update asset command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<Unit> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
    {
        Asset asset = new Asset(request.Name, request.SerialNumber)
        {
            Id = request.Id,
            Description = request.Description,
            Make = request.Make,
            Model = request.Model,
            Category = request.Category,
            SubCategory = request.SubCategory,
            Type = request.Type,
            Status = request.Status
        };

        _assetRepository.Update(asset);
        return Unit.Task;
    }
}
