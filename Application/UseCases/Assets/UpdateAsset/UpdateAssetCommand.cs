using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.UpdateAsset;
public record UpdateAssetCommand(Guid Id, string Name, string SerialNumber, string? Description, string? Make, string? Model, string? Category,
    string? SubCategory, string? Type, string? Status): IRequest<Unit>;