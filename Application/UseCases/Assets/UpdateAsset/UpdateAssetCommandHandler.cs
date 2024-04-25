using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.UpdateAsset;
internal class UpdateAssetCommandHandler : IRequestHandler<UpdateAssetCommand, Unit>
{
    private readonly IAssetRepository _assetRepository;

    public UpdateAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

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
