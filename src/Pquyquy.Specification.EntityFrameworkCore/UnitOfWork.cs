namespace Pquyquy.Specification.EntityFrameworkCore;

/// <inheritdoc/>
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DbContext _context;
    private IDbContextTransaction? _currentTransaction = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
    /// </summary>
    /// <param name="context">The DbContext instance.</param>
    public UnitOfWork(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public virtual ICreateRepositoryBase<TEntity> GetCreateRepositoryBase<TEntity>() where TEntity : class
    {
        return new CreateRepositoryBase<TEntity>(_context);
    }

    /// <inheritdoc/>
    public virtual IReadRepositoryBase<TEntity> GetReadRepositoryBase<TEntity>() where TEntity : class
    {
        return new ReadRepositoryBase<TEntity>(_context);
    }

    /// <inheritdoc/>
    public virtual IUpdateRepositoryBase<TEntity> GetUpdateRepositoryBase<TEntity>() where TEntity : class
    {
        return new UpdateRepositoryBase<TEntity>(_context);
    }

    /// <inheritdoc/>
    public virtual IDeleteRepositoryBase<TEntity> GetDeleteRepositoryBase<TEntity>() where TEntity : class
    {
        return new DeleteRepositoryBase<TEntity>(_context);
    }

    /// <inheritdoc/>
    public virtual async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_currentTransaction != null)
        {
            throw new InvalidOperationException("Transaction already exists.");
        }

        _currentTransaction = await _context.Database.BeginTransactionAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            if (_currentTransaction != null)
            {
                await _currentTransaction.CommitAsync(cancellationToken);
            }
        }
        catch (Exception ex)
        {
            await RollBackAsync();
            throw;
        }
    }

    /// <inheritdoc/>
    public virtual async Task RollBackAsync()
    {
        try
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync();
            }
        }
        finally
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }

    /// <inheritdoc/>
    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Disposes the context and transaction resources.
    /// </summary>
    /// <param name="disposing">A boolean value indicating whether the method is called from user code (true) or from the finalizer (false).</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
            }
        }
    }
}
