using MediatR;

namespace Application.UseCases.AssetAllocations.AllocateAssetToOwner;
public record AllocateAssetToOwnerCommand(Guid AssetOwnerId, Guid AssetId) : IRequest<Unit>;

