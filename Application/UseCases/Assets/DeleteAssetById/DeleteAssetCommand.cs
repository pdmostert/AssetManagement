using MediatR;

namespace Application.UseCases.Assets.DeleteAssetById;

/// <summary>
/// Represents a command to delete an asset by its ID.
/// </summary>
public record DeleteAssetCommand(Guid AssetId) : IRequest<Unit>;
