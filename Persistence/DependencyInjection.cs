using Application.Contracts.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;

namespace Persistence;

/// <summary>
/// Provides extension methods to configure persistence services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds persistence services to the service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IAssetDbContext, AssetDbContext>();
        services.AddScoped<IAssetRepository, AssetRepository>();
        services.AddScoped<IAssetOwnerRepository, AssetOwnerRepository>();
        services.AddScoped<IAssetAllocationRepository, AssetAllocationRepository>();

        return services;
    }
}
