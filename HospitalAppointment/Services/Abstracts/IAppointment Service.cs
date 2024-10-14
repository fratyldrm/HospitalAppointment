using HospitalAppointment.Models;
using HospitalAppointment.Models.Dtos.Appointments.Request;
using HospitalAppointment.Models.Dtos.Appointments.Response;

namespace HospitalAppointment.Services.Abstracts
{
    public interface IAppointmentService
    {
        List<AppointmentResponseDto> GetAllAppointments(); // Tüm randevuları al
        Appointment GetById(int id); // ID'ye göre randevuyu al
        Appointment Add(AddAppointmentRequestDto dto); // Yeni randevu ekle
        Appointment Update(Appointment appointment); // Randevuyu güncelle
        Appointment Delete(int id); // Randevuyu sil
    }
}
