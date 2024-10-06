using System.Linq.Expressions;

namespace GardasarCode.Repository.Interfaces;

/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISpecification<T>
{
    /// <summary>
    ///
    /// </summary>
    IEnumerable<Expression<Func<T, bool>>> Criterias { get; }

    /// <summary>
    ///
    /// </summary>
    bool AsNoTracking { get; }
}

/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TResult"></typeparam>
public interface ISpecification<T, TResult> : ISpecification<T>
{
    /// <summary>
    ///
    /// </summary>
    public Expression<Func<T, TResult>> Selector { get; }

    /// <summary>
    ///
    /// </summary>
    public bool Distinct { get; }
}
