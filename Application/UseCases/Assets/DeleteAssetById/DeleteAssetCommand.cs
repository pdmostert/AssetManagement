using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.DeleteAssetById;

/// <summary>
/// Represents a command to delete an asset by its ID.
/// </summary>
public record DeleteAssetCommand(Guid AssetId) : IRequest<Unit>;
