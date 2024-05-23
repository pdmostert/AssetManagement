using Application.UseCases.Assets.CreateAsset;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Web.Components.Pages.AssetOwners;
public partial class AssetOwnerAddPage
{
    [Inject] public NavigationManager _navigationManager { get; set; }
    [Inject] public IMediator mediator { get; set; }
    [Parameter] public Guid Id { get; set; }
    protected AssetOwner AssetOwner { get; set; } = new AssetOwner();


    protected async Task HandleValidSubmit()
    {

    }
    protected void Cancel()
    {
        _navigationManager.NavigateTo("/asset-owners");
    }

}