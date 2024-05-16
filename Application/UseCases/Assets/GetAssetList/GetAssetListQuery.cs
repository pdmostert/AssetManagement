using Domain;
using MediatR;

namespace Application.UseCases.Assets.GetAssetList;

/// <summary>
/// Represents a query to get a list of assets.
/// </summary>
public record GetAssetListQuery : IRequest<List<Asset>>
{
}
