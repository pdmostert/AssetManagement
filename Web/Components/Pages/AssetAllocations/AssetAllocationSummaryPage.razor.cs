using Application.DTOs;
using Application.UseCases.AssetAllocations.GetAssetSummary;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Web.Components.Pages.AssetAllocations;
public partial class AssetAllocationSummaryPage
{
    [Inject] public IMediator mediator { get; set; }
    [Inject] public NavigationManager _navigationManager { get; set; }

    protected List<AssetSummaryDTO> assetSummaryDTOs { get; set; } = new List<AssetSummaryDTO>();
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
        assetSummaryDTOs = await mediator.Send(new GetAssetSummaryQuery());
    }
}