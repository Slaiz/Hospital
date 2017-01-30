using System.Collections.Generic;
using Hospital_ClassLibrary.Abstract;
using Hospital_ClassLibrary.Model;

namespace Hospital_ClassLibrary.Concrate
{
    public class EFPatientRepository:IPatientRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<PatientModel> Patients
        {
            get { return context.Patients; }
        }
    }
}