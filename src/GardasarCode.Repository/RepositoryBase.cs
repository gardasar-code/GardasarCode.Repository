using System.Runtime.CompilerServices;
using GardasarCode.Repository.Helpers;
using GardasarCode.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GardasarCode.Repository;

/// <summary>
///
/// </summary>
/// <param name="dbContext"></param>
/// <typeparam name="TK"></typeparam>
public class RepositoryBase<TK>(TK dbContext) : IRepository where TK : DbContext
{
    private DbContext DbContext { get; } = dbContext;

    /// <inheritdoc />
    public async Task<T> AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class
    {
        var result = await DbContext.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        return result.Entity;
    }

    /// <inheritdoc />
    public void SetValues<T>(T entity, T newEntity)
        where T : class
    {
        DbContext.Entry(entity).CurrentValues.SetValues(newEntity);
    }

    /// <inheritdoc />
    public async Task<T?> FirstOrDefaultAsync<T>(ISpecification<T> spec, CancellationToken cancellationToken = default)
        where T : class
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc />
    public ConfiguredCancelableAsyncEnumerable<TResult> AsAsyncEnumerableStream<T, TResult>(
        ISpecification<T, TResult> spec,
        CancellationToken cancellationToken = default) where T : class
    {
        var query = SpecificationEvaluator<T, TResult>.GetQuery(DbContext.Set<T>().AsQueryable(), spec);
        return query.AsAsyncEnumerable().WithCancellation(cancellationToken).ConfigureAwait(false);
    }

    private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : class
    {
        return SpecificationEvaluator<T>.GetQuery(DbContext.Set<T>().AsQueryable(), spec);
    }
}
