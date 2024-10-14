namespace HospitalAppointment.Models.Dtos.Appointments.Request;

public class AddAppointmentRequestDto
{
    public Guid PatientId { get; set; }
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
}
