using Application.Contracts.Persistence;
using Domain;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Persistence.Repository;

/// <summary>
/// Represents a generic repository for entities.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
internal class GenericRepository<T> : IGenericRepository<T> where T : Entity
{
    private readonly IAssetDbContext<T> _assetDbContext;
    private readonly string _fileName;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
    /// </summary>
    /// <param name="assetDbContext">The asset database context.</param>
    /// <param name="fileName">The name of the file.</param>
    public GenericRepository(IAssetDbContext<T> assetDbContext, string fileName)
    {
        _assetDbContext = assetDbContext;
        _fileName = fileName;
    }

    /// <summary>
    /// Adds an entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task Add(T entity)
    {
        List<T> existingEntities = _assetDbContext.Load(_fileName).Result;

        if (existingEntities == null)
        {
            existingEntities = new List<T>();
        }

        existingEntities.Add(entity);

        _assetDbContext.Save(_fileName, existingEntities);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Deletes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task Delete(T entity)
    {
        List<T> existingEntities = _assetDbContext.Load(_fileName).Result;

        if (existingEntities == null)
        {
            existingEntities = new List<T>();
        }

        existingEntities.Remove(existingEntities.First(x => x.Id == entity.Id));
        _assetDbContext.Save(_fileName, existingEntities);
        return Task.FromResult("OK");
    }

    /// <summary>
    /// Gets an entity by its ID from the repository.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>A task representing the asynchronous operation and containing the entity.</returns>
    public Task<T> GetById(Guid id)
    {
        List<T> existingEntities = _assetDbContext.Load(_fileName).Result;

        if (existingEntities == null)
        {
            existingEntities = new List<T>();
        }

        return Task.FromResult(existingEntities.First(x => x.Id == id));
    }

    /// <summary>
    /// Gets all entities from the repository.
    /// </summary>
    /// <returns>A task representing the asynchronous operation and containing the list of entities.</returns>
    public Task<List<T>> ListAll()
    {
        List<T> existingEntities = _assetDbContext.Load(_fileName).Result;

        if (existingEntities == null)
        {
            existingEntities = new List<T>();
        }

        return Task.FromResult(existingEntities);
    }

    /// <summary>
    /// Updates an entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task Update(T entity)
    {
        List<T> existingEntities = _assetDbContext.Load(_fileName).Result;

        if (existingEntities == null)
        {
            existingEntities = new List<T>();
        }

        // remove current item from list by id and add new item in its place
        existingEntities.Remove(existingEntities.First(x => x.Id == entity.Id));
        existingEntities.Add(entity);

        _assetDbContext.Save(_fileName, existingEntities);
        return Task.FromResult("OK");
    }
}
