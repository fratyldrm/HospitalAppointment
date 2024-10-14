using HospitalAppointment.Models;
using HospitalAppointment.Models.Dtos.Appointments.Request;
using HospitalAppointment.Models.Dtos.Appointments.Response;
using HospitalAppointment.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HospitalAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _appointmentService.GetAllAppointments();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _appointmentService.GetById(id);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Message); // Hata mesajını döndür
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(AddAppointmentRequestDto dto)
        {
            var result = _appointmentService.Add(dto);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Message); // Hata mesajını döndür
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result); // Randevu oluşturulduktan sonra dönen sonucu belirtin.
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, Appointment appointment)
        {
            appointment.Id = id; // Randevunun ID'sini güncelle
            var result = _appointmentService.Update(appointment);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Message); // Hata mesajını döndür
            }
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _appointmentService.Delete(id);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Message); // Hata mesajını döndür
            }
            return Ok(result);
        }
    }
}
