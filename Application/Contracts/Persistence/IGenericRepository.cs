using Domain;

namespace Application.Contracts.Persistence;

/// <summary>
/// Represents a generic repository interface for CRUD operations.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public interface IGenericRepository<T> where T : Entity
{
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The entity with the specified identifier.</returns>
    Task<T> GetById(Guid id);

    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    Task<List<T>> ListAll();

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    Task Add(T entity);

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    Task Update(T entity);

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    Task Delete(T entity);
}
