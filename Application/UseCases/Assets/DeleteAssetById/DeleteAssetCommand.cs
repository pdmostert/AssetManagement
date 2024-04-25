using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Assets.DeleteAssetById;
public record DeleteAssetCommand(Guid AssetId): IRequest<Unit>;