using Application.DTOs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence;

/// <summary>
/// Represents the interface for the asset repository.
/// </summary>
public interface IAssetRepository : IGenericRepository<Asset>
{
    // No additional members to document, this is a place holder for future methods, specific to the asset repository.
    Task<AssetSummaryDTO> GetAssetSummary();
}
