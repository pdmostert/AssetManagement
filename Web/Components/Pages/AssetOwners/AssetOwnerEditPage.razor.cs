using Application.UseCases.AssetOwners.GetAssetOwnerById;
using Application.UseCases.AssetOwners.UpdateAssetowner;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Web.Components.Pages.AssetOwners;
public partial class AssetOwnerEditPage
{
    [Inject] public NavigationManager _navigationManager { get; set; }
    [Inject] public IMediator mediator { get; set; }
    [Parameter] public Guid Id { get; set; }
    protected AssetOwner AssetOwner { get; set; } = new AssetOwner();



    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(500);
        await GetData();
        await base.OnInitializedAsync();
    }

    private async Task GetData()
    {
        AssetOwner = await mediator.Send(new GetAssetOwnerByIdQuery(Id));
        StateHasChanged();
    }

    protected async Task HandleValidSubmit()
    {
        await mediator.Send(new UpdateAssetOwnerCommand(AssetOwner.Id, AssetOwner.FullName, AssetOwner.Email, AssetOwner.PhoneNumber, AssetOwner.Department));
        _navigationManager.NavigateTo("/asset-owners");
    }
    protected void Cancel()
    {
        _navigationManager.NavigateTo("/asset-owners");
    }

}