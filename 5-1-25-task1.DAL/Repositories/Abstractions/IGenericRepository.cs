namespace _5_1_25_task1.DAL.Repositories.Abstractions;
public interface IGenericRepository<T> where T : class, new()
{
    DbSet<T> Table { get; }

    Task AddAsync(T entity);

    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(int id);

    void Update(T entity);

    void Delete(T entity);

    Task SaveChangesAsync();
}
