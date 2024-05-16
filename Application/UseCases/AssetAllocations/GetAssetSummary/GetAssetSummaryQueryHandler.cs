using Application.Contracts.Persistence;
using Application.DTOs;
using MediatR;

namespace Application.UseCases.AssetAllocations.GetAssetSummary;

internal class GetAssetSummaryQueryHandler : IRequestHandler<GetAssetSummaryQuery, List<AssetSummaryDTO>>
{
    private readonly IAssetAllocationRepository _assetAllocationRepository;

    public GetAssetSummaryQueryHandler(IAssetAllocationRepository assetAllocationRepository)
    {
        _assetAllocationRepository = assetAllocationRepository;
    }

    public async Task<List<AssetSummaryDTO>> Handle(GetAssetSummaryQuery request, CancellationToken cancellationToken)
    {
        var assetSummary = await _assetAllocationRepository.GetAssetSummary();
        return assetSummary;
    }
}

