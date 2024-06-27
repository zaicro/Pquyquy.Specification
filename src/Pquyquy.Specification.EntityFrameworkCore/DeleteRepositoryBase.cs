namespace Pquyquy.Specification.EntityFrameworkCore;

/// <inheritdoc/>
public class DeleteRepositoryBase<TEntity> : IDeleteRepositoryBase<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteRepositoryBase{TEntity}"/> class.
    /// </summary>
    /// <param name="context">The DbContext instance.</param>
    public DeleteRepositoryBase(DbContext context)
    {
        _dbSet = context.Set<TEntity>() ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        await Task.CompletedTask;
    }

    /// <inheritdoc/>
    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _dbSet.RemoveRange(entities);
        await Task.CompletedTask;
    }

    /// <summary>
    /// Disposes resources used by the repository.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes resources used by the repository.
    /// </summary>
    /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }
}
