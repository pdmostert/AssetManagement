using MediatR;

namespace Application.UseCases.AssetOwners.CreateAssetOwner;
public record CreateAssetOwnerCommand(string FullName, string? Email, string? PhoneNumber, string? Department) : IRequest<Unit>;
