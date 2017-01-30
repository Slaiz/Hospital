using System.Collections.Generic;
using Hospital_ClassLibrary.Abstract;
using Hospital_ClassLibrary.Model;

namespace Hospital_ClassLibrary.Concrate
{
    public class EFDoctorRepository:IDoctorRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<DoctorModel> Doctors
        {
            get { return context.Doctors; }
        }
    }
}