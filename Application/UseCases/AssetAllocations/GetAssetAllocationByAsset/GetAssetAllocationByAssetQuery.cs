using Application.DTOs;
using MediatR;

namespace Application.UseCases.AssetAllocations.GetAssetAllocationByAsset;
public record GetAssetAllocationByAssetQuery() : IRequest<List<AssetAllocationDto>>;