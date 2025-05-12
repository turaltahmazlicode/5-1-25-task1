using _5_1_25_task1.DAL.Repositories.Abstractions;

namespace _5_1_25_task1.BL.Services.Concretes;
public class DepartmentService
{
    public DepartmentService(IGenericRepository<Department> repositoy) => _repositoy = repositoy;

    private readonly IGenericRepository<Department> _repositoy;

    public async Task AddAsync(Department entity)
    {

    }

    public void Delete(Department entity)
    {
    }

    public IQueryable<Department> GetAll()
    {
        return null;
    }

    public async Task<Department?> GetByIdAsync(int id)
    {
        return null;
    }

    public async Task SaveChangesAsync()
    {
    }

    public void Update(Department entity)
    {
    }
}
