using Application.UseCases.Assets.CreateAsset;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation;
public class AssetManagementApp
{
    private readonly IConfiguration _configuration;
    private readonly IMediator _mediator;
    private bool exitApp = false;

    public AssetManagementApp(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _mediator = mediator;
    }

    public void Run(string[] args)
    {
        while (!exitApp)
        {
            DisplayMenu();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    DisplayAssets();
                    break;
                case "2":
                    AddAsset();
                    break;
                case "3":
                    UpdateAsset();
                    break;
                case "4":
                    DeleteAsset();
                    break;
                case "5":
                    ExportToCsv();
                    break;
                case "99":
                    exitApp = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void ExportToCsv()
    {
        throw new NotImplementedException();
    }

    private void DeleteAsset()
    {
        throw new NotImplementedException();
    }

    private void UpdateAsset()
    {
        throw new NotImplementedException();
    }

    private async Task AddAsset()
    {
        var asset = GetAssetFromUser();
        var result = await _mediator.Send(new CreateAssetCommand(asset["Name"], asset["SerialNumber"], asset["Description"],
            asset["Make"], asset["Model"], asset["Category"], asset["SubCategory"], asset["Type"], asset["Status"]));

    }

    private Dictionary<string,string> GetAssetFromUser()
    {
        Dictionary<string, string> asset = new Dictionary<string, string>();    

        Console.Write("Enter Asset Name:");
        asset.Add("Name", Console.ReadLine());
        Console.Write("Enter Asset Description:");
        asset.Add("Description", Console.ReadLine());
        Console.Write("Enter Asset Make:");
        asset.Add("Make", Console.ReadLine());
        Console.Write("Enter Asset Model:");
        asset.Add("Model", Console.ReadLine());
        Console.Write("Enter Asset Serial Number:");
        asset.Add("SerialNumber", Console.ReadLine());
        Console.Write("Enter Asset Category:");
        asset.Add("Category", Console.ReadLine());
        Console.Write("Enter Asset SubCategory:");
        asset.Add("SubCategory", Console.ReadLine());
        Console.Write("Enter Asset Type:");
        asset.Add("Type", Console.ReadLine());
        Console.Write("Enter Asset Status:");
        asset.Add("Status", Console.ReadLine());

        return asset;

    }

    private void DisplayAssets()
    {

        throw new NotImplementedException();
    }

    private void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Asset Management App");
        Console.WriteLine("1. Display Assets");
        Console.WriteLine("2. Add Asset");
        Console.WriteLine("3. Update Asset");
        Console.WriteLine("4. Delete Asset");
        Console.WriteLine("5. Export to CSV");
        Console.WriteLine("99. Exit");
        Console.Write("Please enter your choice:");

    }
}
