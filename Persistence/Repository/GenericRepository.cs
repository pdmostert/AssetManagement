using Application.Contracts.Persistence;
using Domain;
using Newtonsoft.Json;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Persistence.Repository;

/// <summary>
/// Represents a generic repository for entities.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
internal class GenericRepository<T> : IGenericRepository<T> where T : Entity
{
    private readonly IDbConnection _dbConnection;
    


    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
    /// </summary>
    /// <param name="assetDbContext">The asset database context.</param>
    /// <param name="fileName">The name of the file.</param>
    public GenericRepository(IAssetDbContext assetDbContext)
    {
        _dbConnection = assetDbContext.CreateConnection();

    }

    public Task Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> ListAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(T entity)
    {
        throw new NotImplementedException();
    }
}
