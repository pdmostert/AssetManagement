using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.CreateAsset;

/// <summary>
/// Command handler for creating an asset.
/// </summary>
internal class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, Unit>
{
    private readonly IAssetRepository _assetRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateAssetCommandHandler"/> class.
    /// </summary>
    /// <param name="assetRepository">The asset repository.</param>
    public CreateAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    /// <summary>
    /// Handles the create asset command.
    /// </summary>
    /// <param name="request">The create asset command.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<Unit> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
    {
        Asset asset = new Asset(request.Name, request.SerialNumber)
        {
            Description = request.Description,
            Make = request.Make,
            Model = request.Model,
            Category = request.Category,
            SubCategory = request.SubCategory,
            Type = request.Type,
            Status = request.Status
        };
        _assetRepository.Add(asset);
        return Unit.Task;
    }
}
