using Application.Contracts.Persistence;
using Domain;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Persistence.Repository;

internal class GenericRepository<T> : IGenericRepository<T> where T : Entity
{
    private readonly IAssetDbContext<T> _assetDbContext;
    private readonly string _fileName;


    public GenericRepository(IAssetDbContext<T> assetDbContext, string fileName)
    {
        _assetDbContext = assetDbContext;
        _fileName = fileName;
    }
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

    public Task<T> GetById(Guid id)
    {
        List<T> existingEntities = _assetDbContext.Load(_fileName).Result;

        if (existingEntities == null)
        {
            existingEntities = new List<T>();
        }


        return Task.FromResult(existingEntities.First(x=>x.Id == id));
    }

    public Task<List<T>> ListAll()
    {
        List<T> existingEntities = _assetDbContext.Load(_fileName).Result;

        if (existingEntities == null)
        {
            existingEntities = new List<T>();
        }

        return Task.FromResult(existingEntities);
    }

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