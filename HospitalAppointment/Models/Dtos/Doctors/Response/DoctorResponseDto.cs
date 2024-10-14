namespace HospitalAppointment.Models.Dtos.Doctors.Response
{
    public class DoctorResponseDto
    {
        public string Name { get; set; }
        public string Branch { get; set; }

        public static implicit operator DoctorResponseDto(Doctor doctor)
        {
            return new DoctorResponseDto
            {
                Name = doctor.Name,
                Branch = doctor.Branch.ToString()
            };
        }
    }
}
