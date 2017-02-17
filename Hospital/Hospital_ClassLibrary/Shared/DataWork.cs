using System;
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

        public void AddPatient(string patientName, string patientSurname, string bloodType, DateTime birthDate)
        {
            var context = new HospitalEntities(); ;
            
            Patient pt = new Patient();

            pt.PatientName = patientName;
            pt.PatientSurname = patientSurname;
            pt.BloodType = bloodType;
            pt.BirthDate = birthDate;

            context.Patients.Add(pt);

            context.SaveChanges();

            context.Dispose();
        }

        public void AddExamination(int doctorId, int patientId, DateTime dataStart, TimeSpan timeStart, TimeSpan timeEnd)
        {
            var context = new HospitalEntities(); ;

            Examination exm = new Examination();

            exm.DoctorID = doctorId;
            exm.PatientID = patientId;
            exm.DataStart = dataStart;
            exm.TimeStart = timeStart;
            exm.TimeEnd = timeEnd;

            context.Examinations.Add(exm);

            context.SaveChanges();

            context.Dispose();
        }

        public void DeleteDoctor(Doctor selectedItem)
        {                     
            using (var context = new HospitalEntities())
            {
                var doctor = context.Doctors.First(x => x.DoctorID == selectedItem.DoctorID);

                context.Doctors.Remove(doctor);

                context.SaveChanges();
            }
        }

        public void DeletePatient(Patient selectedItem)
        {
            using (var context = new HospitalEntities())
            {
                var patient = context.Patients.First(x => x.PatientID == selectedItem.PatientID);

                context.Patients.Remove(patient);

                context.SaveChanges();
            }
        }

        public void DeleteExamination(Examination selectedItem)
        {
            using (var context = new HospitalEntities())
            {
                var examination = context.Patients.First(x => x.PatientID == selectedItem.PatientID);

                context.Patients.Remove(examination);

                context.SaveChanges();
            }
        }

        public void UpdateDoctor(Doctor selectedItem, string doctorName, string doctorSurname, string post, int experience)
        {
            var context = new HospitalEntities();

            var doctor = context.Doctors.First(x => x.DoctorID == selectedItem.DoctorID);

            doctor.DoctorName = doctorName;
            doctor.DoctorSurname = doctorSurname;
            doctor.Post = post;
            doctor.Experience = experience;

            context.SaveChanges();

            context.Dispose();
        }

        public void UpdatePatient(Patient selectedItem, string patientName, string patientSurname, string bloodType, DateTime birthDate)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateExamination(Examination selectedItem, int doctorID, int patientId, DateTime dataStart, TimeSpan timeStart, TimeSpan timeEnd)
        {
            throw new System.NotImplementedException();
        }
    }
}