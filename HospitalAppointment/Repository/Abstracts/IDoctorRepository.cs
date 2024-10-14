using HospitalAppointment.Models;

namespace HospitalAppointment.Repository.Abstracts;

public interface IDoctorRepository : IEntityRepository<Doctor>
{

    List<Doctor> GetByBranch(Branch branch); // Branş bazlı doktor araması
}
