namespace Pquyquy.Specification;

/// <inheritdoc/>
public class ReadSpecification<TEntity> : IReadSpecification<TEntity> where TEntity : class
{
    /// <inheritdoc/>
    public Expression<Func<TEntity, bool>> Filter { get; private set; }

    /// <inheritdoc/>
    public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

    /// <inheritdoc/>
    public Expression<Func<TEntity, object>> OrderBy { get; private set; }

    /// <inheritdoc/>
    public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

    /// <inheritdoc/>
    public List<Expression<Func<TEntity, object>>> ThenOrderBy { get; private set; } = [];

    /// <inheritdoc/>
    public int Take { get; private set; }

    /// <inheritdoc/>
    public int Skip { get; private set; }

    /// <inheritdoc/>
    public bool IsPagingEnabled { get; private set; }

    protected void AddFilter(Expression<Func<TEntity, bool>> filterExpression)
    {
        Filter = filterExpression;
    }

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    public ReadSpecification<TEntity> AddOrderBy(Expression<Func<TEntity, object>> orderByexpression)
    {
        OrderBy = orderByexpression;
        return this;
    }

    public ReadSpecification<TEntity> AddOrderByDecending(Expression<Func<TEntity, object>> orderByDecending)
    {
        OrderByDescending = orderByDecending;
        return this;
    }

    public ReadSpecification<TEntity> AddThenOrderBy<TResult>(Expression<Func<TEntity, TResult>> thenOrderByExpression)
    {
        if (OrderBy != null || OrderByDescending != null)
            ThenOrderBy.Add(x => thenOrderByExpression);
        return this;
    }

    public void ApplyPagging(int take, int skip)
    {
        Take = take;
        //Skip = skip;
        IsPagingEnabled = true;
    }
}
