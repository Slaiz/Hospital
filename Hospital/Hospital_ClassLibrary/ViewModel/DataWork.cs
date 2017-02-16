using System.Collections.Generic;
using System.Linq;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace Hospital_ClassLibrary.ViewModel
{
    public class DataWork:IDataWork
    {
        public List<Doctor> GetDoctorList()
        {
            var context = new HospitalEntities();

            var doctors = context.Doctors.ToList();

            context.Dispose();

            return doctors;
        }

        public List<Patient> GetPatientList()
        {
            var context = new HospitalEntities();

            var patients = context.Patients.ToList();

            context.Dispose();

            return patients;
        }

        public List<Examination> GetExaminationList()
        {
            var context = new HospitalEntities();

            var examination = context.Examinations.ToList();

            context.Dispose();

            return examination;
        }

        public void AddDoctor(string doctorName, string doctorSurname, string post, int experience)
        {
            var context = new HospitalEntities();;

            Doctor dr = new Doctor();

            dr.DoctorName = doctorName;
            dr.DoctorSurname = doctorSurname;
            dr.Post = post;
            dr.Experience = experience;

            context.Doctors.Add(dr);

            context.SaveChanges();

            context.Dispose();
        }

        public void AddPatient()
        {
            throw new System.NotImplementedException();
        }

        public void AddExamination()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteDoctor()
        {
            throw new System.NotImplementedException();
        }

        public void DeletePatient()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteExamination()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateDoctor()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePatient()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateExamination()
        {
            throw new System.NotImplementedException();
        }
    }
}