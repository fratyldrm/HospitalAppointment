using HospitalAppointment.Models;
using HospitalAppointment.Models.Dtos.Appointments.Request;
using HospitalAppointment.Models.Dtos.Appointments.Response;
using HospitalAppointment.Models.ReturnModels;
using HospitalAppointment.Repository.Abstractions;
using HospitalAppointment.Repository.Abstracts;
using HospitalAppointment.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace HospitalAppointment.Services.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public ReturnModel<List<AppointmentResponseDto>> GetAllAppointments()
        {
            var appointments = _appointmentRepository.GetAll();
            var response = appointments.Select(a => new AppointmentResponseDto
            {
                Id = a.Id,
                PatientName = a.PatientName,
                AppointmentDate = a.AppointmentDate,
                DoctorId = a.DoctorId
            }).ToList();

            return new ReturnModel<List<AppointmentResponseDto>>
            {
                Message = "Randevular başarıyla alındı.",
                Success = true,
                Data = response,
                StatusCode = HttpStatusCode.OK
            };
        }

        public ReturnModel<Appointment> GetById(int id)
        {
            var appointment = _appointmentRepository.GetById(id);
            if (appointment == null)
            {
                return new ReturnModel<Appointment>
                {
                    Message = "Randevu bulunamadı.",
                    Success = false,
                    Data = null,
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            return new ReturnModel<Appointment>
            {
                Message = "Randevu başarıyla alındı.",
                Success = true,
                Data = appointment,
                StatusCode = HttpStatusCode.OK
            };
        }

        public ReturnModel<Appointment> Add(AddAppointmentRequestDto dto)
        {
            if (dto.AppointmentDate < DateTime.Now.AddDays(3))
            {
                return new ReturnModel<Appointment>
                {
                    Message = "Randevu tarihi en az 3 gün sonrası olmalıdır.",
                    Success = false,
                    Data = null,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }

            var appointment = new Appointment
            {
                PatientName = dto.PatientName,
                AppointmentDate = dto.AppointmentDate,
                DoctorId = dto.DoctorId
            };

            var createdAppointment = _appointmentRepository.Add(appointment);

            return new ReturnModel<Appointment>
            {
                Message = "Randevu başarıyla oluşturuldu.",
                Success = true,
                Data = createdAppointment,
                StatusCode = HttpStatusCode.Created
            };
        }

        public ReturnModel<Appointment> Update(Appointment appointment)
        {
            var updatedAppointment = _appointmentRepository.Update(appointment);
            return new ReturnModel<Appointment>
            {
                Message = "Randevu başarıyla güncellendi.",
                Success = true,
                Data = updatedAppointment,
                StatusCode = HttpStatusCode.OK
            };
        }

        public ReturnModel<Appointment> Delete(int id)
        {
            var deletedAppointment = _appointmentRepository.Delete(id);
            if (deletedAppointment == null)
            {
                return new ReturnModel<Appointment>
                {
                    Message = "Silinecek randevu bulunamadı.",
                    Success = false,
                    Data = null,
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            return new ReturnModel<Appointment>
            {
                Message = "Randevu başarıyla silindi.",
                Success = true,
                Data = deletedAppointment,
                StatusCode = HttpStatusCode.OK
            };
        }

        public void RemoveExpiredAppointments()
        {
            var appointments = _appointmentRepository.GetAll();
            var expiredAppointments = appointments.Where(a => a.AppointmentDate < DateTime.Now).ToList();

            foreach (var appointment in expiredAppointments)
            {
                _appointmentRepository.Delete(appointment.Id);
            }
        }

        // IAppointmentService arayüzündeki metotların uygulanması
        ReturnModel<List<AppointmentResponseDto>> IAppointmentService.GetAllAppointments()
        {
            return GetAllAppointments();
        }

        ReturnModel<Appointment> IAppointmentService.GetById(int id)
        {
            return GetById(id); 
        }

        ReturnModel<Appointment> IAppointmentService.Add(AddAppointmentRequestDto dto)
        {
            return Add(dto); 
        }

        ReturnModel<Appointment> IAppointmentService.Update(Appointment appointment)
        {
            return Update(appointment); // var olan metodu çağır
        }

        ReturnModel<Appointment> IAppointmentService.Delete(int id)
        {
            return Delete(id); 
        }
    }
}
