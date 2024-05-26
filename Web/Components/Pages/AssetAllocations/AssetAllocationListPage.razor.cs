using Application.DTOs;
using Application.UseCases.AssetAllocations.GetAssetAllocationByAsset;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Web.Components.Pages.AssetAllocations;
public partial class AssetAllocationListPage
{

    [Inject] public NavigationManager _navigationManager { get; set; }
    [Inject] public IMediator mediator { get; set; }

    protected List<AssetAllocationDto> _assets = new List<AssetAllocationDto>();
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
        _assets = await mediator.Send(new GetAssetAllocationByAssetQuery());
    }

    protected async Task AddAssetAllocation()
    {

    }


}