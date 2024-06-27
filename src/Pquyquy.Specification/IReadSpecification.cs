namespace Pquyquy.Specification;

/// <summary>
/// Represents a specification for reading entities of type TEntity.
/// </summary>
/// <typeparam name="TEntity">The type of entities to read.</typeparam>
public interface IReadSpecification<TEntity> where TEntity : class
{
    /// <summary>
    /// Gets or sets the filter expression used to filter entities based on certain criteria.
    /// </summary>
    Expression<Func<TEntity, bool>> Filter { get; }

    /// <summary>
    /// Gets or sets the list of expressions used to specify related entities to include in the query.
    /// </summary>
    List<Expression<Func<TEntity, object>>> Includes { get; }

    /// <summary>
    /// Gets or sets the order by expression used to order entities.
    /// </summary>
    Expression<Func<TEntity, object>> OrderBy { get; }

    /// <summary>
    /// Gets or sets the order by descending expression used to order entities in descending order.
    /// </summary>
    Expression<Func<TEntity, object>> OrderByDescending { get; }

    /// <summary>
    /// Gets or sets the list of then by expressions used to further order entities after the initial order.
    /// </summary>
    List<Expression<Func<TEntity, object>>> ThenOrderBy { get; }

    /// <summary>
    /// Gets or sets the number of entities to return.
    /// </summary>
    int Take { get; }

    /// <summary>
    /// Gets or sets the number of entities to skip.
    /// </summary>
    int Skip { get; }

    /// <summary>
    /// Gets a value indicating whether paging is enabled.
    /// </summary>
    bool IsPagingEnabled { get; }
}
