using System.Collections.Generic;
using Hospital_ClassLibrary.Model;

namespace Hospital_ClassLibrary.Abstract
{
    public interface IPatientRepository
    {
        IEnumerable<PatientModel> Patients { get; }
    }
}