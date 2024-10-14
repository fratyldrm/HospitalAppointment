namespace HospitalAppointment.Models
{
    public sealed class Role : Entity
    {
        public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
