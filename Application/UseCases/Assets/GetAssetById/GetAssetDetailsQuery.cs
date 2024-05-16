using Domain;
using MediatR;

namespace Application.UseCases.Assets.GetAssetById;

/// <summary>
/// Represents a query to get asset details by ID.
/// </summary>
public record GetAssetDetailsQuery(Guid AssetId) : IRequest<Asset>;
