using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.GetAssetById;

/// <summary>
/// Represents a query to get asset details by ID.
/// </summary>
public record GetAssetDetailsQuery(Guid AssetId) : IRequest<Asset>;
