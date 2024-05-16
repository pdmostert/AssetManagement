using Domain;
using MediatR;

namespace Application.UseCases.AssetOwners.GetAssetOwnerList;

public record GetAssetOwnersQuery() : IRequest<List<AssetOwner>>;