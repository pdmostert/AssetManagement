using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

/// <summary>
/// Represents the asset database context.
/// </summary>
internal class AssetDbContext : IAssetDbContext<Asset>
{
    /// <summary>
    /// Loads the assets from the specified file.
    /// </summary>
    /// <param name="fileName">The name of the file to load.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of loaded assets.</returns>
    public Task<List<Asset>> Load(string fileName)
    {
        //build path to file
        string path = Environment.CurrentDirectory;
        string fileNameAndPath = $"{path}\\{fileName}";

        //read json file and convert to list
        if (File.Exists(fileNameAndPath))
        {
            string json = File.ReadAllText(fileNameAndPath);
            List<Asset> assets = JsonConvert.DeserializeObject<List<Asset>>(json);
            return Task.FromResult(assets);
        }

        return Task.FromResult(new List<Asset>());
    }

    /// <summary>
    /// Saves the assets to the specified file.
    /// </summary>
    /// <param name="fileName">The name of the file to save.</param>
    /// <param name="data">The list of assets to save.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task Save(string fileName, List<Asset> data)
    {
        // Convert list to JSON string
        string json = JsonConvert.SerializeObject(data);

        //build path to file
        string path = Environment.CurrentDirectory;
        string fileNameAndPath = $"{path}\\{fileName}";

        //check if file exists
        if (!File.Exists(fileNameAndPath))
        {
            // Create file if it does not exist
            File.Create(fileNameAndPath).Dispose();
        }

        // Write JSON string to file
        File.WriteAllText(fileNameAndPath, json);

        return Task.CompletedTask;
    }
}
