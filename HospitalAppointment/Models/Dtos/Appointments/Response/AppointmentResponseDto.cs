namespace HospitalAppointment.Models.Dtos.Appointments.Response;

public class AppointmentResponseDto
{
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string DoctorName { get; set; }

    public static implicit operator AppointmentResponseDto(Appointment appointment)
    {
        var doctor = GetDoctorById(appointment.DoctorId);

        return new AppointmentResponseDto
        {
            PatientName = appointment.PatientName,
            AppointmentDate = appointment.AppointmentDate,
            DoctorName = doctor?.Name
        };
    }

    private Doctor GetDoctorById(int doctorId)
    {
        
        return new Doctor(); 
    }
}
