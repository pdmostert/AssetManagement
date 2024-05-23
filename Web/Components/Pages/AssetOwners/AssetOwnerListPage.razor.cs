using Application.UseCases.AssetOwners.GetAssetOwnerList;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Web.Components.Pages.AssetOwners;
public partial class AssetOwnerListPage
{
    [Inject] public IMediator mediator { get; set; }
    [Inject] public NavigationManager _navigationManager { get; set; }
    protected bool loading = true;
    protected List<AssetOwner> AssetOwners { get; set; } = new List<AssetOwner>();

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(500);
        await GetData();
        await base.OnInitializedAsync();
        loading = false;
    }

    private async Task GetData()
    {
        AssetOwners = await mediator.Send(new GetAssetOwnersQuery());
    }

    protected void EditAssetOwner(AssetOwner assetOwner)
    {
        _navigationManager.NavigateTo($"/asset-owner-edit/{assetOwner.Id}");
    }
    protected void DeleteAssetOwner(AssetOwner assetOwner)
    {
        _navigationManager.NavigateTo($"/asset-owners/delete/{assetOwner.Id}");
    }

    protected void AddAssetOwner()
    {
        _navigationManager.NavigateTo("/asset-owner-add");
    }

}