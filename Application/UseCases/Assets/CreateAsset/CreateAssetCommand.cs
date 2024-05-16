using MediatR;

namespace Application.UseCases.Assets.CreateAsset;

/// <summary>
/// Represents a command to create an asset.
/// </summary>
public record CreateAssetCommand(string Name, string SerialNumber, string? Description, string? Make, string? Model, string? Category,
    string? SubCategory, string? Type, string? Status) : IRequest<Unit>;

