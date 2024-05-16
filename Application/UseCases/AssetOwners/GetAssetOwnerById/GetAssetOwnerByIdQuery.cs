using Domain;
using MediatR;

namespace Application.UseCases.AssetOwners.GetAssetOwnerById;

public record GetAssetOwnerByIdQuery(Guid AssetOwnerId) : IRequest<AssetOwner>;
