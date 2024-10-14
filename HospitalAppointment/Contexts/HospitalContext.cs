using HospitalAppointment.Models; 
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Contexts
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Docker kurulu olanlar 
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=HospitalAppointment_db; User=sa; Password=23768722984Ff.; TrustServerCertificate=true");

           
        }

        public DbSet<Doctor> Doctors { get; set; } // Doktor tablosu
        public DbSet<Appointment> Appointments { get; set; } // Randevu tablosu
    }
}




