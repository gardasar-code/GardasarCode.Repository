using System.Runtime.CompilerServices;

namespace GardasarCode.Repository.Interfaces;

/// <summary>
///
/// </summary>
public interface IRepository
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<T> AddAsync<T>(T entity, CancellationToken cancellationToken = default) where T : class;

    /// <summary>
    ///
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="newEntity"></param>
    /// <typeparam name="T"></typeparam>
    void SetValues<T>(T entity, T newEntity) where T : class;

    /// <summary>
    ///
    /// </summary>
    /// <param name="spec"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<T?> FirstOrDefaultAsync<T>(ISpecification<T> spec, CancellationToken cancellationToken = default)
        where T : class;

    /// <summary>
    ///
    /// </summary>
    /// <param name="spec"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    ConfiguredCancelableAsyncEnumerable<TResult> AsAsyncEnumerableStream<T, TResult>(ISpecification<T, TResult> spec,
        CancellationToken cancellationToken = default) where T : class;

    /// <summary>
    ///
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
