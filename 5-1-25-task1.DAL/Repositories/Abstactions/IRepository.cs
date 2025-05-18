
using Microsoft.EntityFrameworkCore;

namespace _5_1_25_task1.DAL.Repositories.Abstactions;
public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    public DbSet<TEntity> Table { get; }

    #region Create
    public Task CreateAsync(TEntity entity);
    #endregion

    #region Read
    public IQueryable<TEntity> GetAll(bool isTrancking = false, params string[] includes);
    public IQueryable<TEntity> GetByCondition(Func<TEntity, bool> predicate, bool isTrancking = false, params string[] includes);
    public Task<TEntity?> GetByIdAsync(int id, bool isTrancking = false, params string[] includes);
    #endregion

    #region Update
    public void Update(TEntity entity);
    #endregion

    #region Delete
    public void Delete(TEntity entity);
    #endregion

    public Task<int> SaveChangesAsync();
}
