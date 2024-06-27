namespace Pquyquy.Specification;

/// <summary>
/// Represents a base repository interface for reading entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entities to read.</typeparam>
public interface IReadRepositoryBase<TEntity> : IDisposable where TEntity : class
{
    /// <summary>
    /// Asynchronously retrieves entities based on the provided specification.
    /// </summary>
    /// <param name="specification">The specification to apply to the query.</param>
    Task<IEnumerable<TEntity>> GetAsync(IReadSpecification<TEntity> specification);

    /// <summary>
    /// Asynchronously retrieves all entities.
    /// </summary>
    Task<IEnumerable<TEntity>> GetAllAsync();

    /// <summary>
    /// Asynchronously retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    Task<TEntity?> GetByIdAsync(object id);

    /// <summary>
    /// Executes a raw SQL query and returns a list of entities asynchronously.
    /// </summary>
    /// <param name="sql">The SQL query string.</param>
    /// <param name="parameters">The parameters to be passed to the SQL query.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains a list of entities.</returns>
    Task<IEnumerable<TEntity>> GetByQueryAsync(string sql, params object[] parameters);
}
