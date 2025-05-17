
namespace _5_1_25_task1.DAL.Repositories.Concretes;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    public GenericRepository(AppDbContext appDbContext) => _context = appDbContext;

    private readonly AppDbContext _context;
    public DbSet<T> Table => _context.Set<T>();

    #region Create
    public async Task AddAsync(T entity) => await Table.AddAsync(entity);
    #endregion

    #region Read
    public IQueryable<T> GetAll(bool isTracking = false, params string[] includes)
    {
        var query = Table.AsQueryable();

        query = !isTracking ? query.AsNoTracking() : query;

        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }

    public IQueryable<T> GetByCondition(Func<T, bool> predicate, bool isTracking = false, params string[] includes)
    {
        var query = Table.AsQueryable();

        query = !isTracking ? query.AsNoTracking() : query;

        foreach (var include in includes)
            query = query.Include(include);

        query = query.Where(predicate).AsQueryable();

        return query;
    }

    public async Task<T?> GetByIdAsync(int id, bool isTracking = false, params string[] includes)
    {
        var query = Table.AsQueryable();

        query = !isTracking ? query.AsNoTracking() : query;

        foreach (var include in includes)
            query = query.Include(include);

        return await query.SingleOrDefaultAsync(e => e.Id == id);
    }
    #endregion

    #region Update
    public void Update(T entity) => Table.Update(entity);
    #endregion

    #region Delete
    public void Delete(T entity) => Table.Remove(entity);
    #endregion

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
