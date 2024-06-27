namespace Pquyquy.Specification;

/// <summary>
/// Generic interface for a repository that provides methods for Create operations on entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity to be handled in the repository.</typeparam>
public interface ICreateRepositoryBase<TEntity> : IDisposable where TEntity : class
{
    /// <summary>
    /// Adds an entity to the repository asynchronously.
    /// </summary>
    /// <param name="entity">The entity to be added to the repository.</param>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a collection of entities to the repository asynchronously.
    /// </summary>
    /// <param name="entities">The collection of entities to be added to the repository.</param>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the next value of a specified sequence from the database.
    /// </summary>
    /// <param name="sequenceName">The name of the sequence to get the next value from.</param>
    /// <returns>The next value of the specified sequence as a long.</returns>
    long GetSequence(string sequenceName);
}