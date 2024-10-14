using HospitalAppointment.Models;
using HospitalAppointment.Models.Dtos.Doctors.Request;
using HospitalAppointment.Models.Dtos.Doctors.Response;
using HospitalAppointment.Models.ReturnModels;
using HospitalAppointment.Repository.Abstractions;
using HospitalAppointment.Repository.Abstracts;
using HospitalAppointment.Services.Abstracts;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace HospitalAppointment.Services.Concretes
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public ReturnModel<Doctor> Add(AddDoctorRequestDto dto)
        {
            // DTO'dan Doctor nesnesi oluşturma
            var doctor = new Doctor
            {
                Name = dto.Name,
                Branch = dto.Branch // Enum tipini uygun şekilde atama
            };

            // Yeni doktoru ekleme
            var createdDoctor = _doctorRepository.Add(doctor);

            return new ReturnModel<Doctor>
            {
                Message = "Doktor başarıyla eklendi.",
                Success = true,
                Data = createdDoctor,
                StatusCode = HttpStatusCode.Created
            };
        }

        public ReturnModel<Doctor> Delete(int id)
        {
            var deletedDoctor = _doctorRepository.Delete(id);
            if (deletedDoctor == null)
            {
                return new ReturnModel<Doctor>
                {
                    Message = "Silinecek doktor bulunamadı.",
                    Success = false,
                    Data = null,
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            return new ReturnModel<Doctor>
            {
                Message = "Doktor başarıyla silindi.",
                Success = true,
                Data = deletedDoctor,
                StatusCode = HttpStatusCode.OK
            };
        }

        public ReturnModel<List<DoctorResponseDto>> GetAllDoctors()
        {
            var doctors = _doctorRepository.GetAll();
            var response = doctors.Select(d => new DoctorResponseDto
            {
                Id = d.Id,
                Name = d.Name,
                Branch = d.Branch.ToString()
            }).ToList();

            return new ReturnModel<List<DoctorResponseDto>>
            {
                Message = "Doktorlar başarıyla alındı.",
                Success = true,
                Data = response,
                StatusCode = HttpStatusCode.OK
            };
        }

        public ReturnModel<Doctor> GetById(int id)
        {
            var doctor = _doctorRepository.GetById(id);
            if (doctor == null)
            {
                return new ReturnModel<Doctor>
                {
                    Message = "Doktor bulunamadı.",
                    Success = false,
                    Data = null,
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            return new ReturnModel<Doctor>
            {
                Message = "Doktor başarıyla alındı.",
                Success = true,
                Data = doctor,
                StatusCode = HttpStatusCode.OK
            };
        }

        public ReturnModel<Doctor> Update(Doctor doctor)
        {
            var updatedDoctor = _doctorRepository.Update(doctor);
            return new ReturnModel<Doctor>
            {
                Message = "Doktor başarıyla güncellendi.",
                Success = true,
                Data = updatedDoctor,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
