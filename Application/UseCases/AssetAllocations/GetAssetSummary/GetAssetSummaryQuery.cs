using Application.DTOs;
using MediatR;

namespace Application.UseCases.AssetAllocations.GetAssetSummary;
public record GetAssetSummaryQuery : IRequest<List<AssetSummaryDTO>>;

