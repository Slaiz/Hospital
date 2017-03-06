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

        void AddDoctor(string doctorName, string doctorSurname, string post, int experience);
        void AddPatient(string patientName, string patientSurname, string bloodType, DateTime birthDate);
        void AddExamination(int doctorID, int patientId, DateTime dataStart, TimeSpan timeStart, TimeSpan timeEnd);

        void DeleteDoctor(Doctor selectedItem);
        void DeletePatient(Patient selectedItem);
        void DeleteExamination(Examination selectedItem);

        void UpdateDoctor(Doctor selectedItem, string doctorName, string doctorSurname, string post, int experience);
        void UpdatePatient(Patient selectedItem, string patientName, string patientSurname, string bloodType, DateTime birthDate);
        void UpdateExamination(Examination selectedItem, int doctorID, int patientId, DateTime dataStart, TimeSpan timeStart, TimeSpan timeEnd);
    }
}