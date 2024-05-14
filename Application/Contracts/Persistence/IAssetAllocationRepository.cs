﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistence;
public interface IAssetAllocationRepository
{
    Task<AssetAllocation> GetAssetAllocationByAssetId(Guid assetId);
    Task<AssetAllocation> GetAssetAllocationByAssetOwnerId(Guid assetOwnerId);


}