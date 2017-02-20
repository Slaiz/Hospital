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
            using (var context = new HospitalEntities())
            {
                var doctors = context.Doctors.ToList();

                return doctors;
            }
        }

        public List<Patient> GetPatientList()
        {
            using (var context = new HospitalEntities())
            {
                var patients = context.Patients.ToList();

                return patients;
            }
        }

        public List<Examination> GetExaminationList()
        {
            using (var context = new HospitalEntities())
            {
                var examination = context.Examinations.ToList();

                return examination;
            }
        }

        public void AddDoctor(string doctorName, string doctorSurname, string post, int experience)
        {
            using (var context = new HospitalEntities())
            {
                Doctor dr = new Doctor();

                dr.DoctorName = doctorName;
                dr.DoctorSurname = doctorSurname;
                dr.Post = post;
                dr.Experience = experience;

                context.Doctors.Add(dr);

                context.SaveChanges();
            }
        }

        public void AddPatient(string patientName, string patientSurname, string bloodType, DateTime birthDate)
        {
            using (var context = new HospitalEntities())
            {
                Patient pt = new Patient();

                pt.PatientName = patientName;
                pt.PatientSurname = patientSurname;
                pt.BloodType = bloodType;
                pt.BirthDate = birthDate;

                context.Patients.Add(pt);

                context.SaveChanges();
            }
        }

        public void AddExamination(int doctorId, int patientId, DateTime dateStart, TimeSpan timeStart, TimeSpan timeEnd)
        {
            using (var context = new HospitalEntities())
            {
                Examination exm = new Examination();

                exm.DoctorID = doctorId;
                exm.PatientID = patientId;
                exm.DataStart = dateStart;
                exm.TimeStart = timeStart;
                exm.TimeEnd = timeEnd;

                context.Examinations.Add(exm);

                context.SaveChanges();
            }
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
            using (var context = new HospitalEntities())
            {
                var doctor = context.Doctors.First(x => x.DoctorID == selectedItem.DoctorID);

                doctor.DoctorName = doctorName;
                doctor.DoctorSurname = doctorSurname;
                doctor.Post = post;
                doctor.Experience = experience;

                context.SaveChanges();
            }
        }

        public void UpdatePatient(Patient selectedItem, string patientName, string patientSurname, string bloodType, DateTime birthDate)
        {
            using (var context = new HospitalEntities())
            {
                var patient = context.Patients.First(x => x.PatientID == selectedItem.PatientID);

                patient.PatientName = patientName;
                patient.PatientSurname = patientSurname;
                patient.BloodType = bloodType;
                patient.BirthDate = birthDate;

                context.SaveChanges();
            }
        }

        public void UpdateExamination(Examination selectedItem, int doctorId, int patientId, DateTime dateStart, TimeSpan timeStart, TimeSpan timeEnd)
        {
            using (var context = new HospitalEntities())
            {
                var examination = context.Examinations.First(x => x.ExaminationID == selectedItem.ExaminationID);

                examination.DoctorID = doctorId;
                examination.PatientID = patientId;
                examination.DataStart = dateStart;
                examination.TimeStart = timeStart;
                examination.TimeEnd = timeEnd;

                context.SaveChanges();
            }
        }
    }
}