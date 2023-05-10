using Data.Enums;

namespace Data.Interfaces
{
    public interface IRepository<TModel, TId> where TModel : class where TId : struct
    {
        IQueryable<TModel> Query();
        Task<ICollection<TModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TModel> GetAsync(TId id, CancellationToken cancellationToken = default);
        Task<bool> TryGetAsync(TId id, out TModel model, CancellationToken cancellationToken = default);
        Task<bool> CheckExistsAsync(Func<TModel, bool> selector, CancellationToken cancellationToken = default);
        Task<TModel> FindAsync(Func<TModel, bool> selector, CancellationToken cancellationToken = default);
        Task<ICollection<TModel>> WhereAsync(Func<TModel, bool> selector, CancellationToken cancellationToken = default);

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        Task<(RepositoryActionResult, TModel)> CreateAsync(TModel model);
        Task<(RepositoryActionResult, TModel)> UpdateAsync(TModel model);
        Task<RepositoryActionResult> DeleteAsync(TId id);
    }
}
