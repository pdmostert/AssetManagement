using Application.Contracts.Persistence;
using Application.DTOs;
using MediatR;

namespace Application.UseCases.AssetAllocations.GetAssetSummary;

/// <summary>
/// Handles the query to get the asset summary.
/// </summary>
internal class GetAssetSummaryQueryHandler : IRequestHandler<GetAssetSummaryQuery, List<AssetSummaryDTO>>
{
    private readonly IAssetAllocationRepository _assetAllocationRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAssetSummaryQueryHandler"/> class.
    /// </summary>
    /// <param name="assetAllocationRepository">The asset allocation repository.</param>
    public GetAssetSummaryQueryHandler(IAssetAllocationRepository assetAllocationRepository)
    {
        _assetAllocationRepository = assetAllocationRepository;
    }

    /// <summary>
    /// Handles the asset summary query.
    /// </summary>
    /// <param name="request">The asset summary query.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of asset summaries.</returns>
    public async Task<List<AssetSummaryDTO>> Handle(GetAssetSummaryQuery request, CancellationToken cancellationToken)
    {
        var assetSummary = await _assetAllocationRepository.GetAssetSummary();
        return assetSummary;
    }
}

