using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace Hospital_ClassLibrary.ViewModel.Interface
{
    public interface IDataWork
    {
        List<Doctor> GetDoctorList();
        List<Patient> GetPatientList();
        List<Examination> GetExaminationList();

        void AddDoctor();
        void AddPatient();
        void AddExamination();

        void DeleteDoctor();
        void DeletePatient();
        void DeleteExamination();

        void UpdateDoctor();
        void UpdatePatient();
        void UpdateExamination();
    }
}