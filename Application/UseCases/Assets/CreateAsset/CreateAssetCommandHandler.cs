using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.CreateAsset;
internal class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, Unit>
{
    private readonly IAssetRepository _assetRepository;

    public CreateAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

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
