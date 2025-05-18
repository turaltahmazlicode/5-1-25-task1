using _5_1_25_task1.DAL.Contexts;
using _5_1_25_task1.DAL.Repositories.Abstactions;
using Microsoft.EntityFrameworkCore;

namespace _5_1_25_task1.DAL.Repositories.Concretes;
public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    public Repository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    private readonly AppDbContext _context;

    public DbSet<TEntity> Table => _context.Set<TEntity>();

    #region Create
    public async Task CreateAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
    }
    #endregion

    #region Read
    public IQueryable<TEntity> GetAll(bool isTrancking = false, params string[] includes)
    {
        var query = Table.AsQueryable();

        query = isTrancking ? query : query.AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }

    public IQueryable<TEntity> GetByCondition(Func<TEntity, bool> predicate, bool isTrancking = false, params string[] includes)
    {
        var query = Table.AsQueryable();

        query = isTrancking ? query : query.AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        query = query.Where(predicate).AsQueryable();

        return query;
    }

    public async Task<TEntity?> GetByIdAsync(int id, bool isTrancking = false, params string[] includes)

    {
        var query = Table.AsQueryable();

        query = isTrancking ? query : query.AsNoTracking();

        foreach (var include in includes)
            query = query.Include(include);

        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }
    #endregion

    #region Update
    public void Update(TEntity entity)
    {
        Table.Update(entity);
    }
    #endregion

    #region Delete
    public void Delete(TEntity entity)
    {
        Table.Remove(entity);
    }
    #endregion

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
