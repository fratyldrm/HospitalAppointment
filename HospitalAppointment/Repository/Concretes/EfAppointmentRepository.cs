using HospitalAppointment.Models;
using HospitalAppointment.Repository.Abstracts;

namespace HospitalAppointment.Repository.Concretes;

public class EfAppointmentRepository : IAppointmentRepository
{

    private readonly HospitalContext _context;

    public AppointmentRepository(HospitalContext context)
    {
        _context = context;
    }





    public Appointment Add(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
        return appointment;
    }

    public Appointment Delete(int id)
    {
        var appointment = _context.Appointments.Find(id);
        if (appointment != null)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }
        return appointment;
    }

    public List<Appointment> GetAll()
    {
        return _context.Appointments.Include(a => a.Doctor).ToList(); // Doktor bilgileriyle birlikte randevuları getir.
    }

    public List<Appointment> GetByDoctorId(int doctorId)
    {
        return _context.Appointments
                       .Include(a => a.Doctor)
                       .Where(a => a.DoctorId == doctorId)
                       .ToList();
    }

    public List<Appointment> GetExpiredAppointments()
    {
        return _context.Appointments
                       .Where(a => a.AppointmentDate < DateTime.Now) // Geçmiş tarihli randevular
                       .ToList();
    }

    public Appointment? GetById(int id)
    {
        return _context.Appointments
                       .Include(a => a.Doctor)
                       .FirstOrDefault(a => a.Id == id);
    }

    public Appointment Update(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
        _context.SaveChanges();
        return appointment;
    }
}
