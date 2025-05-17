namespace _5_1_25_task1.BL.Services.Concretes;
public class DepartmentService
{
    public DepartmentService(IGenericRepository<Department> repositoy) => _repositoy = repositoy;

    private readonly IGenericRepository<Department> _repositoy;

    #region Create
    public async Task AddAsync(Department department)
        => await _repositoy.AddAsync(department);
    #endregion

    #region Read
    public async Task<List<Department>> GetAll(bool isTracking = false, params string[] includes)
        => await _repositoy.GetAll(isTracking, includes).ToListAsync();

    public async Task<List<Department>> GetByCondition(Func<Department, bool> predicate, bool isTracking = false, params string[] includes)
        => await _repositoy.GetByCondition(predicate, isTracking, includes).ToListAsync();

    public async Task<Department?> GetByIdAsync(int id, bool isTracking = false, params string[] includes)
        => await _repositoy.GetByIdAsync(id, isTracking, includes);

    public async Task<Department> GetIfExist(Department department)
    {
        var d = await _repositoy.GetByIdAsync(department.Id);
        if (d is null)
            throw new Exception("department not found");
        return d;
    }

    public async Task<Department> GetIfExist(int id)
    {
        var d = await _repositoy.GetByIdAsync(id);
        if (d is null)
            throw new Exception("department not found");
        return d;
    }
    #endregion

    #region Update
    public async Task Update(Department department)
        => _repositoy.Update(await GetIfExist(department));
    #endregion

    #region Delete
    public async Task Delete(Department department)
        => _repositoy.Delete(await GetIfExist(department));
    #endregion

    public async Task<int> SaveChangesAsync()
        => await _repositoy.SaveChangesAsync();

}