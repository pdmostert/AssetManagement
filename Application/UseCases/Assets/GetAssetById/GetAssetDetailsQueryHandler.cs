using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.GetAssetById;
internal class GetAssetDetailsQueryHandler : IRequestHandler<GetAssetDetailsQuery, Asset>
{
    private readonly IAssetRepository _assetRepository;

    public GetAssetDetailsQueryHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public Task<Asset> Handle(GetAssetDetailsQuery request, CancellationToken cancellationToken)
    {
        return _assetRepository.GetById(request.AssetId);
    }
}
