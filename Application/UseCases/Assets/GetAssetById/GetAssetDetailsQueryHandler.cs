using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.GetAssetById;

/// <summary>
/// Handles the query to get asset details by ID.
/// </summary>
internal class GetAssetDetailsQueryHandler : IRequestHandler<GetAssetDetailsQuery, Asset>
{
    private readonly IAssetRepository _assetRepository;

    public GetAssetDetailsQueryHandler(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    /// <summary>
    /// Handles the request to get asset details by ID.
    /// </summary>
    /// <param name="request">The query request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The asset details.</returns>
    public Task<Asset> Handle(GetAssetDetailsQuery request, CancellationToken cancellationToken)
    {
        return _assetRepository.GetById(request.AssetId);
    }
}
