namespace _5_1_25_task1.DAL.Repositories.Concretes;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
{
    public GenericRepository(AppDbContext appDbContext) => _context = appDbContext;

    private readonly AppDbContext _context;

    public DbSet<T> Table => _context.Set<T>();

    public async Task AddAsync(T entity) => await Table.AddAsync(entity);

    public void Delete(T entity) => Table.Remove(entity);

    public IQueryable<T> GetAll() => Table.AsQueryable();
    public T? GetById(int id) => Table.AsNoTracking().FirstOrDefault(t => t.Id == id);
    public async Task<T?> GetByIdAsync(int id) => await Table.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public void Update(T entity) => Table.Update(entity);
}
