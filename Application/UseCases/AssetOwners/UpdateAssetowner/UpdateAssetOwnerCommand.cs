using MediatR;

namespace Application.UseCases.AssetOwners.UpdateAssetowner;

public record UpdateAssetOwnerCommand(Guid AssetOwnerId, string FullName, string? Email, string? PhoneNumber, string? Department) : IRequest<Unit>;
