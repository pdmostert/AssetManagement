using Application.UseCases.Assets.CreateAsset;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Web.Components.Pages.Assets;
public partial class AssetAddPage
{
    [Inject] public NavigationManager _navigationManager { get; set; }
    [Inject] public IMediator mediator { get; set; }
    [Parameter] public Guid Id { get; set; }
    protected Asset Asset { get; set; } = new Asset();


    protected async Task HandleValidSubmit()
    {
        if (string.IsNullOrEmpty(Asset.Name) || string.IsNullOrEmpty(Asset.SerialNumber))
        {
            return;
        }

        await mediator.Send(new CreateAssetCommand(
            Name: Asset.Name,
            SerialNumber: Asset.SerialNumber,
            Description: Asset.Description,
            Make: Asset.Make,
            Model: Asset.Model,
            Category: Asset.Category,
            SubCategory: Asset.SubCategory,
            Type: Asset.Type,
            Status: Asset.Status));
        _navigationManager.NavigateTo("/assets");
    }
    protected void Cancel()
    {
        _navigationManager.NavigateTo("/assets");
    }

}