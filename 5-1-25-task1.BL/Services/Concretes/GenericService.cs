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

    public List<TEntity> GetBy(Func<TEntity, bool> predicate)
    {
        return _repositoy.GetAll().Where(predicate).ToList();
    }

    public void Update(TEntity entity)
    {
        IsExist(entity);
        _repositoy.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        IsExist(entity);
        _repositoy.Delete(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _repositoy.SaveChangesAsync();
    }

    public TEntity IsExist(TEntity entity)
    {
        var e = _repositoy.GetById(entity.Id);
        if (e is null)
            throw new Exception("Entity not found");
        return e;
    }

    public TEntity IsExistById(int id)
    {
        var e = _repositoy.GetById(id);
        if (e is null)
            throw new Exception("Entity not found");
        return e;
    }
}