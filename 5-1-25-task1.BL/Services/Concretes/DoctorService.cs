using _5_1_25_task1.DAL.Repositories.Abstractions;

namespace _5_1_25_task1.BL.Services.Concretes;
public class DoctorService
{
    public DoctorService(IGenericRepository<Doctor> repositoy) => _repositoy = repositoy;

    private readonly IGenericRepository<Doctor> _repositoy;

    public async Task AddAsync(Doctor entity)
    {

    }

    public void Delete(Doctor entity)
    {
    }

    public IQueryable<Doctor> GetAll()
    {
        return null;
    }

    public async Task<Doctor?> GetByIdAsync(int id)
    {
        return null;
    }

    public async Task SaveChangesAsync()
    {
    }

    public void Update(Doctor entity)
    {
    }
}
