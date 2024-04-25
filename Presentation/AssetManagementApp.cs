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
    private readonly Menu _menu ;

    public AssetManagementApp(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _mediator = mediator;
        _menu = new Menu(_mediator);
    }

    public void Run(string[] args)
    {
        while (!exitApp)
        {
            _menu.DisplayMenu();
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    _menu.DisplayAssets();
                    break;
                case "2":
                    _menu.AddAssetMenu();
                    break;
                case "3":
                    _menu.UpdateAssetMenu();
                    break;
                case "4":
                    _menu.DeleteAssetMenu();
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



 




}
