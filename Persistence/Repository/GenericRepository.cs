using Application.Contracts.Persistence;
using Domain;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Persistence.Repository;

internal class GenericRepository<T> : IGenericRepository<T> where T : class
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