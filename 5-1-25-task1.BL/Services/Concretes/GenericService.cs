using _5_1_25_task1.BL.Services.Abstractions;
using _5_1_25_task1.DAL.Repositories.Abstractions;

namespace _5_1_25_task1.BL.Services.Concretes;
public abstract class GenericService<TEntity> : IGenericService<TEntity>
    where TEntity : BaseEntity, new()
{
    public GenericService(IGenericRepository<TEntity> repositoy) => _repositoy = repositoy;

    protected readonly IGenericRepository<TEntity> _repositoy;

    public async Task AddAsync(TEntity entity)
    {
        await _repositoy.AddAsync(entity);
    }

    public List<TEntity> GetAll()
    {
        return _repositoy.GetAll().ToList();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _repositoy.GetByIdAsync(id);
    }

    public async void Update(TEntity entity)
    {
        if (_repositoy.GetById(entity.Id) == null)
            throw new Exception("Entity not found");
        _repositoy.Update(entity);
    }

    public async void Delete(TEntity entity)
    {
        if (_repositoy.GetById(entity.Id) == null)
            throw new Exception("Entity not found");
        _repositoy.Delete(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _repositoy.SaveChangesAsync();
    }
}