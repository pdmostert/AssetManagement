using Application.UseCases.Assets.GetAssetList;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Web.Components.Pages.Assets;
public partial class AssetListPage
{
    [Inject] public IMediator mediator { get; set; }
    [Inject] public NavigationManager _navigationManager { get; set; }

    protected List<Asset> Assets { get; set; } = new List<Asset>();
    protected bool loading = true;

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(500);
        await GetData();
        await base.OnInitializedAsync();
        loading = false;
    }

    private async Task GetData()
    {
        Assets = await mediator.Send(new GetAssetListQuery());
    }


    protected void EditAsset(Asset asset)
    {
        _navigationManager.NavigateTo($"/asset-edit/{asset.Id}");
    }
    protected void DeleteAsset(Asset asset)
    {
        _navigationManager.NavigateTo($"/assets/delete/{asset.Id}");
    }

    protected void AddAsset()
    {
        _navigationManager.NavigateTo("/asset-add");
    }
}