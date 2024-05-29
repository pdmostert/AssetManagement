using Application.DTOs;
using Application.UseCases.AssetAllocations.AllocateAssetToOwner;
using Application.UseCases.AssetOwners.CreateAssetOwner;
using Application.UseCases.AssetOwners.GetAssetOwnerById;
using Application.UseCases.Assets.GetAssetList;
using Azure.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace Web.Components.Pages.AssetAllocations;
public partial class AllocateAssetToOwnerPage
{
    [Inject] public IMediator mediator { get; set; }
    [Inject] public NavigationManager _navigationManager { get; set; }
    [Parameter] public Guid Id { get; set; }


    protected List<Asset> assets { get; set; } = new List<Asset>();
    protected AssetAllocationDto allocationDto { get; set; } = new AssetAllocationDto();
    protected bool loading = true;


    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(500);
        allocationDto.AssetOwnerId = Id;
        await GetData();
        await base.OnInitializedAsync();
        loading = false;
    }

    private async Task GetData()
    {
        allocationDto.AssetOwner = await mediator.Send(new GetAssetOwnerByIdQuery(Id));
        assets = await mediator.Send(new GetAssetListQuery());
    }

    protected async Task HandleValidSubmit()
    {
        await mediator.Send(new AllocateAssetToOwnerCommand(allocationDto.AssetOwnerId, allocationDto.AssetId));
        _navigationManager.NavigateTo("/asset-allocations");
    }
    protected void Cancel()
    {
        _navigationManager.NavigateTo("/asset-owners");
    }

}