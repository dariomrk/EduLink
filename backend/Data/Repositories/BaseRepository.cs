using Data.Context;
using Data.Enums;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class BaseRepository<TModel, TId> : IRepository<TModel, TId> where TModel : class, IEduLinkModel where TId : struct
    {
        protected readonly EduLinkDbContext _dbContext;
        protected readonly DbSet<TModel> _dbSet;
        protected readonly ILogger _logger;

        public BaseRepository(EduLinkDbContext dbContext, ILogger logger)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TModel>();
            _logger = logger;
        }

        protected RepositoryActionResult SaveChanges()
        {
            return _dbContext.SaveChanges() > 0
                ? RepositoryActionResult.Success
                : RepositoryActionResult.NoChanges;
        }

        protected async Task<RepositoryActionResult> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken) > 0
                ? RepositoryActionResult.Success
                : RepositoryActionResult.NoChanges;
        }

        protected RepositoryActionResult TryRepositoryAction(Func<RepositoryActionResult> action)
        {
            try
            {
                return action();
            }
            catch (Exception e)
            {
                _logger.LogError("Caught {message}:{exception} in BaseRepository", e.Message, e);
                return RepositoryActionResult.Error;
            }
        }

        protected async Task<RepositoryActionResult> TryRepositoryActionAsync(Func<Task<RepositoryActionResult>> actionAsync)
        {
            try
            {
                return await actionAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("Caught {message}:{exception} in BaseRepository", e.Message, e);
                return RepositoryActionResult.Error;
            }
        }

        public IQueryable<TModel> Query() =>
            _dbSet
                .AsQueryable()
                .AsNoTracking();

        public async Task<ICollection<TModel>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await Query()
                .ToListAsync(cancellationToken);

        public async Task<TModel?> FindByIdAsync(TId id, CancellationToken cancellationToken = default) =>
            await _dbSet.FindAsync(new object[] { id }, cancellationToken: cancellationToken);

        public async Task<TModel?> FindAsync(Expression<Func<TModel, bool>> selector, CancellationToken cancellationToken = default) =>
            await Query()
            .FirstOrDefaultAsync(selector, cancellationToken);

        public async Task<ICollection<TModel>> WhereAsync(Expression<Func<TModel, bool>> selector, CancellationToken cancellationToken = default) =>
            await Query()
                .Where(selector)
                .ToListAsync(cancellationToken);

        public async Task<bool> CheckExistsAsync(Expression<Func<TModel, bool>> selector, CancellationToken cancellationToken = default) =>
            await FindAsync(selector, cancellationToken) is null;

        public async Task BeginTransactionAsync() =>
            await _dbContext.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync() =>
            await _dbContext.Database.CommitTransactionAsync();

        public async Task RollbackTransactionAsync() =>
            await _dbContext.Database.RollbackTransactionAsync();

        public async Task<(RepositoryActionResult Result, TModel? Created)> CreateAsync(TModel model)
        {
            TModel? createdModel = null;

            var result = await TryRepositoryActionAsync(async () =>
            {
                createdModel = (await _dbSet.AddAsync(model)).Entity;
                return await SaveChangesAsync();
            });

            return (result, createdModel);
        }

        public async Task<(RepositoryActionResult Result, TModel? Updated)> UpdateAsync(TModel model)
        {
            TModel? updatedModel = null;

            var result = await TryRepositoryActionAsync(async () =>
            {
                updatedModel = _dbSet.Update(model).Entity;
                return await SaveChangesAsync();
            });

            return (result, updatedModel);
        }

        public async Task<RepositoryActionResult> DeleteAsync(TId id)
        {
            return await TryRepositoryActionAsync(async () =>
            {
                var model = await FindByIdAsync(id);

                if (model is null)
                    return RepositoryActionResult.NoChanges;

                _dbSet.Remove(model);
                return await SaveChangesAsync();
            });
        }
    }
}
