using Microsoft.Data.SqlClient;
using System.Data;

namespace Pquyquy.Specification.EntityFrameworkCore;

/// <inheritdoc/>
public class CreateRepositoryBase<TEntity> : ICreateRepositoryBase<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateRepositoryBase{TEntity}"/> class.
    /// </summary>
    /// <param name="context">The DbContext instance.</param>
    public CreateRepositoryBase(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = context.Set<TEntity>() ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
        return entities;
    }

    /// <inheritdoc/>
    public long GetSequence(string sequenceName)
    {
        if (string.IsNullOrEmpty(sequenceName))
        {
            throw new ArgumentException("Sequence name cannot be null or empty", nameof(sequenceName));
        }

        try
        {
            var p = new SqlParameter("@result", SqlDbType.BigInt)
            {
                Direction = ParameterDirection.Output
            };
            _context.Database.ExecuteSqlRaw($"SET @result = NEXT VALUE FOR {sequenceName}", p);
            return (long)p.Value;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to get next value for sequence '{sequenceName}'", ex);
        }
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
            _context?.Dispose();
        }
    }
}
