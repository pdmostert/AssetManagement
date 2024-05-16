namespace Application.DTOs;
/// <summary>
/// Represents a summary of an asset.
/// </summary>
public class AssetSummaryDTO
{
    /// <summary>
    /// Gets or sets the full name of the asset.
    /// </summary>
    public string FullName { get; set; }

    /// <summary>
    /// Gets or sets the count of the asset.
    /// </summary>
    public int AssetCount { get; set; }
}
