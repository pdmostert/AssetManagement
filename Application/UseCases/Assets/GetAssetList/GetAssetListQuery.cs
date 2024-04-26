using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.GetAssetList;

/// <summary>
/// Represents a query to get a list of assets.
/// </summary>
public record GetAssetListQuery : IRequest<List<Asset>>
{
}
