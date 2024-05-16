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

    /// <summary>
    /// Handles the command to create a new asset owner.
    /// </summary>
    /// <param name="request">The command to create a new asset owner.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
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
