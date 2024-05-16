using Application.Contracts.Persistence;
using Domain;
using MediatR;

namespace Application.UseCases.AssetOwners.CreateAssetOwner;
public class CreateAssetOwnerCommandHandler : IRequestHandler<CreateAssetOwnerCommand, Unit>
{
    private readonly IAssetOwnerRepository _assetOwnerRepository;

    public CreateAssetOwnerCommandHandler(IAssetOwnerRepository assetOwnerRepository)
    {
        _assetOwnerRepository = assetOwnerRepository;
    }

    public async Task<Unit> Handle(CreateAssetOwnerCommand request, CancellationToken cancellationToken)
    {
        AssetOwner assetOwner = new()
        {
            FullName = request.FullName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Department = request.Department
        };

        await _assetOwnerRepository.Add(assetOwner);
        return await Unit.Task;

    }
}