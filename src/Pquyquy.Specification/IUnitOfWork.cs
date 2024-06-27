namespace Pquyquy.Specification;

/// <summary>
/// Interface representing a unit of work for managing transactions and saving changes in a repository.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets the repository for creating entities of the specified type.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which to get the repository.</typeparam>
    /// <returns>The repository for creating entities of the specified type.</returns>
    ICreateRepositoryBase<TEntity> GetCreateRepositoryBase<TEntity>() where TEntity : class;

    /// <summary>
    /// Gets the repository for reading entities of the specified type.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which to get the repository.</typeparam>
    /// <returns>The repository for reading entities of the specified type.</returns>
    IReadRepositoryBase<TEntity> GetReadRepositoryBase<TEntity>() where TEntity : class;

    /// <summary>
    /// Gets the repository for updating entities of the specified type.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which to get the repository.</typeparam>
    /// <returns>The repository for updating entities of the specified type.</returns>
    IUpdateRepositoryBase<TEntity> GetUpdateRepositoryBase<TEntity>() where TEntity : class;

    /// <summary>
    /// Gets the repository for deleting entities of the specified type.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity for which to get the repository.</typeparam>
    /// <returns>The repository for deleting entities of the specified type.</returns>
    IDeleteRepositoryBase<TEntity> GetDeleteRepositoryBase<TEntity>() where TEntity : class;

    /// <summary>
    /// Begins a new transaction asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Commits the transaction asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    Task CommitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Rolls back the transaction asynchronously.
    /// </summary>
    Task RollBackAsync();

    /// <summary>
    /// Saves all changes made in this unit of work to the underlying database asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Optional cancellation token to cancel the operation.</param>
    /// <returns>A task representing the asynchronous operation. The task result is the number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
