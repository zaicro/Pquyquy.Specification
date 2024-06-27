namespace Pquyquy.Specification;

/// <summary>
/// Generic interface for a repository that provides methods for Delete operations on entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity to be handled in the repository.</typeparam>
public interface IDeleteRepositoryBase<TEntity> : IDisposable where TEntity : class
{
    /// <summary>
    /// Deletes an entity from the repository asynchronously.
    /// </summary>
    /// <param name="entity">The entity to be deleted from the repository.</param>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a collection of entities from the repository asynchronously.
    /// </summary>
    /// <param name="entities">The collection of entities to be deleted from the repository.</param>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
}
