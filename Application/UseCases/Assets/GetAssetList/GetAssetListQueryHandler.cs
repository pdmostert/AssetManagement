using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.GetAssetList;

/// <summary>
/// Handles the query to get a list of assets.
/// </summary>
internal class GetAssetListQueryHandler : IRequestHandler<GetAssetListQuery, List<Asset>>
{
    private readonly IAssetRepository _assetRepository;

    public GetAssetListQueryHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    /// <summary>
    /// Handles the request to get a list of assets.
    /// </summary>
    /// <param name="request">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A list of assets.</returns>
    public Task<List<Asset>> Handle(GetAssetListQuery request, CancellationToken cancellationToken)
    {
        return _assetRepository.ListAll();
    }
}
