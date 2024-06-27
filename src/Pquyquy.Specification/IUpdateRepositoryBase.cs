namespace Pquyquy.Specification;

/// <summary>
/// Generic interface for a repository that provides methods for Update operations on entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity to be handled in the repository.</typeparam>
public interface IUpdateRepositoryBase<TEntity> : IDisposable where TEntity : class
{
    /// <summary>
    /// Updates an entity in the repository asynchronously.
    /// </summary>
    /// <param name="entity">The entity to be updated in the repository.</param>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a collection of entities in the repository asynchronously.
    /// </summary>
    /// <param name="entities">The collection of entities to be updated in the repository.</param>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
}
