using _5_1_25_task1.DAL.Models;

namespace _5_1_25_task1.BL.Services.Abstractions;
public interface IGenericService<TEntity> where TEntity : BaseEntity, new()
{
    public Task AddAsync(TEntity entity);
    public List<TEntity> GetAll();
    public Task<TEntity?> GetByIdAsync(int id);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public Task SaveChangesAsync();
}
