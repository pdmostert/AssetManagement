using Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.DeleteAssetById;
internal class DeleteAssetCommandHandler : IRequestHandler<DeleteAssetCommand, Unit>
{
    private readonly IAssetRepository _assetRepository;

    public DeleteAssetCommandHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public Task<Unit> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
    {
        var assetToDelete = _assetRepository.GetById(request.AssetId).Result;

        _assetRepository.Delete(assetToDelete);
        return Unit.Task;
    }
}
