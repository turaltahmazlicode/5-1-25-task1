using _5_1_25_task1.DAL.Repositories.Abstractions;

namespace _5_1_25_task1.BL.Services.Concretes;
public class DoctorService(IGenericRepository<Doctor> repositoy) : GenericService<Doctor>(repositoy)
{

}
