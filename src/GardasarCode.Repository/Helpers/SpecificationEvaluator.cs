using GardasarCode.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GardasarCode.Repository.Helpers;

/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
public static class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
    {
        var query = inputQuery;
        if (specification.AsNoTracking) query = query.AsNoTracking();
        if (specification.Criterias.Any())
            query = specification.Criterias.Aggregate(query, (current, criteria) => current.Where(criteria));

        return query;
    }
}

/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TResult"></typeparam>
public static class SpecificationEvaluator<T, TResult> where T : class
{
    public static IQueryable<TResult> GetQuery(IQueryable<T> inputQuery, ISpecification<T, TResult> specification)
    {
        var query = inputQuery;
        if (specification.AsNoTracking) query = query.AsNoTracking();
        if (specification.Criterias.Any())
            query = specification.Criterias.Aggregate(query, (current, criteria) => current.Where(criteria));

        var selectQuery = query.Select(specification.Selector);

        if (specification.Distinct)
            selectQuery = selectQuery.Distinct();

        return selectQuery;
    }
}
