using HospitalAppointment.Models.Enums;

namespace HospitalAppointment.Models;

//public enum Branch
//{
//    Genel,
//    Kardiyolog,
//    Dermatolog,
//    Nörolog
//    // Diğer branşlar eklenebilir
//}

public class Doctor:Entity
{
    public string Name { get; set; }
    public Branch Branch { get; set; } // Enum olarak tanımlanan Branch
    public List<Appointment> Patients { get; set; } = new List<Appointment>();
}
