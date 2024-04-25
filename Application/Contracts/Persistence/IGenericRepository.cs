using Domain;

namespace Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : Entity
{
    Task<T> GetById(Guid id); 
    Task<List<T>> ListAll();
    Task Add(T entity) ;
    Task Update(T entity);
    Task Delete(T entity);
}