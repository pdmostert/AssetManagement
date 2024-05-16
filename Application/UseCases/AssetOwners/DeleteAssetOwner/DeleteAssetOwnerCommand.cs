using MediatR;

namespace Application.UseCases.AssetOwners.DeleteAssetOwner;

public record DeleteAssetOwnerCommand(Guid AssetOwnerId) : IRequest<Unit>;
