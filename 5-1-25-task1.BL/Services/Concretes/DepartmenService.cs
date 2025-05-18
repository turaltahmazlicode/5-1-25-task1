using _5_1_25_task1.DAL.Models;
using _5_1_25_task1.DAL.Repositories.Abstactions;
using Microsoft.EntityFrameworkCore;

namespace _5_1_25_task1.BL.Services.Concretes;
public class DepartmentService
{
    public DepartmentService(IRepository<Department> repository)
    {
        _repository = repository;
    }

    private readonly IRepository<Department> _repository;

    #region Create
    public async Task CreateAsync(Department department)
    {
        await _repository.CreateAsync(department);
    }
    #endregion

    #region Read
    public async Task<List<Department>> GetAll(bool isTrancking = false, params string[] includes)
    {
        return await _repository.GetAll(isTrancking, includes).ToListAsync();
    }

    public async Task<List<Department>> GetByCondition(Func<Department, bool> predicate, bool isTrancking = false, params string[] includes)
    {
        return await _repository.GetByCondition(predicate, isTrancking, includes).ToListAsync();
    }

    public async Task<Department?> GetByIdAsync(int id, bool isTrancking = false, params string[] includes)
    {
        return await _repository.GetByIdAsync(id, isTrancking, includes);
    }

    public async Task<Department?> GetIfExist(Department department)
    {
        return await GetByIdAsync(department.Id) ?? throw new Exception("department not found.");
    }
    public async Task<Department?> GetIfExist(int id)
    {
        return await GetByIdAsync(id) ?? throw new Exception("department not found.");
    }
    #endregion

    #region Update
    public async Task Update(Department department)
    {
        await GetIfExist(department);
        _repository.Update(department);
    }
    #endregion

    #region Delete
    public async Task Delete(Department department)
    {
        _repository.Delete(await GetIfExist(department));
    }
    #endregion

    public async Task<int> SaveChangesAsync()
    {
        return await _repository.SaveChangesAsync();
    }
}
