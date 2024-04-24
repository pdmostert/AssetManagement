using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;
internal class AssetDbContext : IAssetDbContext<Asset>
{
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
