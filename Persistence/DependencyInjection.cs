using Application.Contracts.Persistence;
using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        services.AddScoped<IAssetDbContext<Asset>, AssetDbContext>();
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IAssetRepository, AssetRepository>();
        return services;
    }
}
