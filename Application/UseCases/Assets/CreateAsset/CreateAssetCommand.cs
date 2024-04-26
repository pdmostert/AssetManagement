using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.CreateAsset;

/// <summary>
/// Represents a command to create an asset.
/// </summary>
public record CreateAssetCommand(string Name, string SerialNumber, string? Description, string? Make, string? Model, string? Category,
    string? SubCategory, string? Type, string? Status) : IRequest<Unit>;

