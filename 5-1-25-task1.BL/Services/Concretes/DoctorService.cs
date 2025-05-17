namespace _5_1_25_task1.BL.Services.Concretes;
public class DoctorService
{
    public DoctorService(IGenericRepository<Doctor> repositoy) => _repositoy = repositoy;

    private readonly IGenericRepository<Doctor> _repositoy;

    #region Create
    public async Task AddAsync(Doctor doctor)
        => await _repositoy.AddAsync(doctor);
    #endregion

    #region Read
    public async Task<List<Doctor>> GetAll(bool isTracking = false, params string[] includes)
        => await _repositoy.GetAll(isTracking, includes).ToListAsync();

    public async Task<List<Doctor>> GetByCondition(Func<Doctor, bool> predicate, bool isTracking = false, params string[] includes)
        => await _repositoy.GetByCondition(predicate, isTracking, includes).ToListAsync();

    public async Task<Doctor?> GetByIdAsync(int id, bool isTracking = false, params string[] includes)
        => await _repositoy.GetByIdAsync(id, isTracking, includes);

    public async Task<Doctor> GetIfExist(Doctor doctor)
    {
        var d = await _repositoy.GetByIdAsync(doctor.Id);
        if (d is null)
            throw new Exception("Doctor not found");
        return d;
    }

    public async Task<Doctor> GetIfExist(int id)
    {
        var d = await _repositoy.GetByIdAsync(id);
        if (d is null)
            throw new Exception("Doctor not found");
        return d;
    }
    #endregion

    #region Update
    public async Task Update(Doctor doctor)
        => _repositoy.Update(await GetIfExist(doctor));
    #endregion

    #region Delete
    public async Task Delete(Doctor doctor)
        => _repositoy.Delete(await GetIfExist(doctor));
    #endregion

    public async Task<int> SaveChangesAsync()
        => await _repositoy.SaveChangesAsync();

}