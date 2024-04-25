using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.GetAssetList;
internal class GetAssetListQueryHandler : IRequestHandler<GetAssetListQuery, List<Asset>>
{
    private readonly IAssetRepository _assetRepository;

    public GetAssetListQueryHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public Task<List<Asset>> Handle(GetAssetListQuery request, CancellationToken cancellationToken)
    {
        return _assetRepository.ListAll();
    }
}
