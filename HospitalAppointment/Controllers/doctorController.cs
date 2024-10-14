using HospitalAppointment.Models;
using HospitalAppointment.Models.Dtos.Doctors.Request;
using HospitalAppointment.Models.Dtos.Doctors.Response;
using HospitalAppointment.Models.ReturnModels;
using HospitalAppointment.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HospitalAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _doctorService.GetAllDoctors();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _doctorService.GetById(id);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Message);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(AddDoctorRequestDto dto)
        {
            var result = _doctorService.Add(dto);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Message);
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateDoctorRequestDto dto)
        {
            var doctor = new Doctor
            {
                Id = id,
                Name = dto.Name,
                Branch = dto.Branch,

            };

            var result = _doctorService.Update(doctor);
            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Message);
                return Ok(result);
            }

            [HttpDelete("delete/{id}")]
            public IActionResult Delete(int id)
            {
                var result = _doctorService.Delete(id);
                if (!result.Success)
                {
                    return StatusCode((int)result.StatusCode, result.Message);
                }
                return Ok(result);
            }
        }
    }
}