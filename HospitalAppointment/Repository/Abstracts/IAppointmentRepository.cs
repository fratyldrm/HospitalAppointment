using HospitalAppointment.Models;

namespace HospitalAppointment.Repository.Abstracts;

public interface IAppointmentRepository : IEntityRepository<Appointment>
{
    List<Appointment> GetByDoctorId(int doctorId); // Belirli bir doktorun randevuları
    List<Appointment> GetExpiredAppointments(); // Zamanı geçmiş randevuları almak için
}
