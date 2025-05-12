namespace _5_1_25_task1.DAL.Repositories.Abstractions;
public interface IGenericRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }

    Task AddAsync(T entity);

    IQueryable<T> GetAll();
    T? GetById(int id);
    Task<T?> GetByIdAsync(int id);

    void Update(T entity);

    void Delete(T entity);

    Task SaveChangesAsync();
}
