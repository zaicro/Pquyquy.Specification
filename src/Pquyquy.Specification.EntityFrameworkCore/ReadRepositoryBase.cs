namespace Pquyquy.Specification.EntityFrameworkCore;

/// <inheritdoc/>
public class ReadRepositoryBase<TEntity> : IReadRepositoryBase<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;

    /// <summary>
    /// Initializes a new instance of the <see cref="ReadRepositoryBase{TEntity}"/> class.
    /// </summary>
    /// <param name="context">The DbContext instance.</param>
    public ReadRepositoryBase(DbContext context)
    {
        _dbSet = context.Set<TEntity>() ?? throw new ArgumentNullException(nameof(context));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> GetAsync(IReadSpecification<TEntity> specification)
    {
        IQueryable<TEntity> query = _dbSet;

        if (specification.Filter != null)
        {
            query = query.Where(specification.Filter);
        }

        if (specification.OrderBy != null)
        {
            query = query.OrderBy(specification.OrderBy);
            foreach (var property in specification.ThenOrderBy)
            {
                query = ((IOrderedQueryable<TEntity>)query).ThenBy(property);
            }
        }

        if (specification.Includes != null)
        {
            foreach (var includeExpression in specification.Includes)
            {
                query = query.Include(includeExpression);
            }
        }

        return await query.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<TEntity?> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TEntity>> GetByQueryAsync(string sql, params object[] parameters)
    {
        return await _dbSet.FromSqlRaw(sql, parameters).ToListAsync();
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
    /// Releases the unmanaged resources used by the <see cref="ReadRepositoryBase{TEntity}"/> and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
        }
    }
}
