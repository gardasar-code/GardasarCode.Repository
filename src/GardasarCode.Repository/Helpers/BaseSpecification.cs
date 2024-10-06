using System.Linq.Expressions;
using GardasarCode.Repository.Interfaces;

namespace GardasarCode.Repository.Helpers;

/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseSpecification<T> : ISpecification<T>
{
    //// <inheritdoc />
    public IEnumerable<Expression<Func<T, bool>>> Criterias { get; } = new List<Expression<Func<T, bool>>>();

    /// <inheritdoc />
    public bool AsNoTracking { get; protected init; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="criteria"></param>
    protected void AddCriteria(Expression<Func<T, bool>> criteria)
    {
        ((List<Expression<Func<T, bool>>>)Criterias).Add(criteria);
    }
}

public abstract class BaseSpecification<T, TResult> : BaseSpecification<T>, ISpecification<T, TResult>
{
    /// <inheritdoc />
    public Expression<Func<T, TResult>> Selector { get; protected init; } = x => default!;

    /// <inheritdoc />
    public bool Distinct { get; protected init; }
}
