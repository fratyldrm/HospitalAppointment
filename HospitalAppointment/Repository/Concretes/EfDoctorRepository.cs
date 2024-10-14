using HospitalAppointment.Models;
using HospitalAppointment.Repository.Abstracts;

namespace HospitalAppointment.Repository.Concretes;

public class EfDoctorRepository:IDoctorRepository
{
    private readonly HospitalContext _context;

    public DoctorRepository(HospitalContext context)
    {
        _context = context;
    }

    public Doctor Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
        return doctor;
    }

    public Doctor Delete(int id)
    {
        var doctor = _context.Doctors.Find(id);
        if (doctor != null)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
        return doctor;
    }

    public List<Doctor> GetAll()
    {
        return _context.Doctors.Include(d => d.Patients).ToList(); // Hastalarıyla birlikte doktorları getir.
    }

    public List<Doctor> GetByBranch(Branch branch)
    {
        return _context.Doctors
                       .Include(d => d.Patients)
                       .Where(d => d.Branch == branch)
                       .ToList();
    }

    public Doctor? GetById(int id)
    {
        return _context.Doctors
                       .Include(d => d.Patients)
                       .FirstOrDefault(d => d.Id == id);
    }

    public Doctor Update(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
        _context.SaveChanges();
        return doctor;
    }
}
