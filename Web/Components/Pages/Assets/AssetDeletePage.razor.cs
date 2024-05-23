using Application.UseCases.Assets.DeleteAssetById;
using Application.UseCases.Assets.GetAssetById;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Web.Components.Pages.Assets;
public partial class AssetDeletePage
{

    [Inject] public IMediator mediator { get; set; }
    [Inject] public NavigationManager _navigationManager { get; set; }
    [Parameter] public Guid Id { get; set; }

    protected Asset Asset { get; set; } = new Asset();

    protected override async Task OnInitializedAsync()
    {
        if (Id == Guid.Empty)
        {
            Asset = new Asset();
            return;
        }
        await GetData(Id);
        await base.OnInitializedAsync();
    }

    private async Task GetData(Guid id)
    {
        Asset = await mediator.Send(new GetAssetDetailsQuery(id));
    }
    protected async Task Delete()
    {
        await mediator.Send(new DeleteAssetCommand(Id));
        _navigationManager.NavigateTo("/assets");
    }
    protected void Cancel()
    {
        _navigationManager.NavigateTo("/assets");
    }
}