using Data.Enums;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IRepository<TModel, TId> where TModel : class, IEduLinkModel where TId : struct
    {
        IQueryable<TModel> Query();
        Task<ICollection<TModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TModel?> FindByIdAsync(TId id, CancellationToken cancellationToken = default);
        Task<TModel?> FindAsync(Expression<Func<TModel, bool>> selector, CancellationToken cancellationToken = default);
        Task<ICollection<TModel>> WhereAsync(Expression<Func<TModel, bool>> selector, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TModel, bool>> selector, CancellationToken cancellationToken = default);
        Task<bool> CheckExistsAsync(Expression<Func<TModel, bool>> selector, CancellationToken cancellationToken = default);

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        Task<(RepositoryActionResult Result, TModel? Created)> CreateAsync(TModel model);
        Task<(RepositoryActionResult Result, TModel? Updated)> UpdateAsync(TModel model);
        Task<RepositoryActionResult> DeleteAsync(TId id);
    }
}
