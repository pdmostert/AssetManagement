using Application.UseCases.Assets.CreateAsset;
using Application.UseCases.Assets.DeleteAssetById;
using Application.UseCases.Assets.GetAssetById;
using Application.UseCases.Assets.GetAssetList;
using Application.UseCases.Assets.UpdateAsset;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation;
public class Menu
{
    private readonly IMediator _mediator;

    public Menu(IMediator mediator)
    {
        _mediator = mediator;
    }

    public  void DisplayMenu()
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

    public void AddAssetMenu()
    {
        var asset = GetAssetFromUserMenu();
        var result =  _mediator.Send(new CreateAssetCommand(asset["Name"], asset["SerialNumber"], asset["Description"],
            asset["Make"], asset["Model"], asset["Category"], asset["SubCategory"], asset["Type"], asset["Status"])).Result;
    }

    private  Dictionary<string, string> GetAssetFromUserMenu()
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

    public void DisplayAssets()
    {
        // Display Assets
        var assetList = _mediator.Send(new GetAssetListQuery()).Result;
        Console.WriteLine("Asset List");
        Console.WriteLine("ID\tName\tSerial Number\tDescription\tMake\tModel\tCategory\tSubCategory\tType\tStatus");
        foreach (var asset in assetList)
        {
            Console.WriteLine($"{asset.Id}\t{asset.Name}\t{asset.SerialNumber}\t{asset.Description}\t{asset.Make}\t{asset.Model}\t{asset.Category}\t{asset.SubCategory}\t{asset.Type}\t{asset.Status}");
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

    }


    public  void DeleteAssetMenu()
    {
        DisplayAssets();
        Console.Write("Enter Asset ID to delete:");
        var assetId = Console.ReadLine();
        Guid selectedAssetId = Guid.Empty;
        bool success = Guid.TryParse(assetId, out selectedAssetId);

        while (!success)
        {
            Console.WriteLine("Invalid Asset ID. Please try again.");
            assetId = Console.ReadLine();
            success = Guid.TryParse(assetId, out selectedAssetId);
        }



        _mediator.Send(new DeleteAssetCommand(Guid.Parse(assetId)));

    }

    public  void UpdateAssetMenu()
    {
        DisplayAssets();
        Console.Write("Enter Asset ID to update:");
        var assetId = Console.ReadLine();
        Guid selectedAssetId = Guid.Empty;
        bool success = Guid.TryParse(assetId, out selectedAssetId);
        while (!success)
        {
            Console.WriteLine("Invalid Asset ID. Please try again.");
            assetId = Console.ReadLine();
            success = Guid.TryParse(assetId, out selectedAssetId);
        }
        
        var selectedAsset = _mediator.Send(new GetAssetDetailsQuery(Guid.Parse(assetId))).Result;
        Console.WriteLine("Asset Details");
        Console.WriteLine("ID\t\t\t\t\tName\tSerial Number\tDescription\tMake\tModel\tCategory\tSubCategory\tType\tStatus");
        Console.WriteLine($"{selectedAsset.Id}\t{selectedAsset.Name}\t{selectedAsset.SerialNumber}\t{selectedAsset.Description}\t{selectedAsset.Make}\t{selectedAsset.Model}\t{selectedAsset.Category}\t{selectedAsset.SubCategory}\t{selectedAsset.Type}\t{selectedAsset.Status}");
        
        Console.WriteLine("Enter new details for the asset:");
        var asset = GetAssetFromUserMenu();
        var result = _mediator.Send(new UpdateAssetCommand(Guid.Parse(assetId), asset["Name"], asset["SerialNumber"], asset["Description"],
                       asset["Make"], asset["Model"], asset["Category"], asset["SubCategory"], asset["Type"], asset["Status"])).Result;



    }




}
