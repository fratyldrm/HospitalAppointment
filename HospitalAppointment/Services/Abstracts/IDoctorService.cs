using HospitalAppointment.Models;
using HospitalAppointment.Models.Dtos.Doctors.Request;
using HospitalAppointment.Models.Dtos.Doctors.Response;

namespace HospitalAppointment.Services.Abstracts
{
    public interface IDoctorService
    {
        List<DoctorResponseDto> GetAllDoctors(); // Tüm doktorları al
        Doctor GetById(int id); // ID'ye göre doktoru al
        Doctor Add(AddDoctorRequestDto dto); // Yeni doktor ekle
        Doctor Update(Doctor doctor); // Doktoru güncelle
        Doctor Delete(int id); // Doktoru sil
    }
}
