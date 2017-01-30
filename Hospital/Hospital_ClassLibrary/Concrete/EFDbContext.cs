using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Hospital_ClassLibrary.Model;

namespace Hospital_ClassLibrary.Concrate
{
    public class EFDbContext : DbContext
    {
        public EFDbContext() : base("DBConnection")
        { }

        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<ExaminationModel> Examinations { get; set; }
    }
}