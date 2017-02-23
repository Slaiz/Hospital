using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Hospital_ClassLibrary.Model;
using Hospital_ClassLibrary.ViewModel.Interface;

namespace Hospital_ClassLibrary.Shared
{
    public class DataWork : IDataWork
    {
        public static event EventHandler<Doctor> OnAddDoctor;
        public static event EventHandler<Patient> OnAddPatient;
        public static event EventHandler<Examination> OnAddExamination;
        public static event EventHandler<Doctor> OnDeleteDoctor;
        public static event EventHandler<Patient> OnDeletePatient;
        public static event EventHandler<Examination> OnDeleteExamination;
        public static event Action<Doctor, Doctor> OnUpdateDoctor;
        public static event Action<Patient, Patient> OnUpdatePatient;
        public static event Action<Examination, Examination> OnUpdateExamination;
        public static event EventHandler OnUpdateMainModel;

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

        public List<MainModel> GetMainList()
        {
            using (var context = new HospitalEntities())
            {
                var main = (from e in context.Examinations
                            join d in context.Doctors on e.DoctorID equals d.DoctorID
                            join p in context.Patients on e.PatientID equals p.PatientID
                            select new MainModel()
                            {
                                ExaminationID = e.ExaminationID,
                                DateStart = e.DateStart,
                                TimeStart = e.TimeStart,
                                TimeEnd = e.TimeEnd,
                                DoctorId = d.DoctorID,
                                DoctorName = d.DoctorName,
                                DoctorSurname = d.DoctorSurname,
                                Post = d.Post,
                                Experience = d.Experience,
                                PatientId = p.PatientID,
                                PatientName = p.PatientName,
                                PatientSurname = p.PatientSurname,
                                BloodType = p.BloodType,
                                BirthDate = p.BirthDate
                            }).ToList();

                return main;
            }
        }

        public List<string> GetFindParamtrList()
        {
            List<string> list = new List<string>();

            list.Add(NameFindParamtr.Patient_Name.ToString());
            list.Add(NameFindParamtr.Doctor_Name.ToString());
            list.Add(NameFindParamtr.Date.ToString());

            return list;
        }

        public List<MainModel> Find(NameFindParamtr findParametr, string nameParametr)
        {
            switch (findParametr)
            {
                case NameFindParamtr.Patient_Name:
                    {
                        var main = GetMainList().Where(x => x.PatientName.Contains(nameParametr)).ToList();
                        return main;
                    }
                case NameFindParamtr.Doctor_Name:
                    {
                        var main = GetMainList().Where(x => x.DoctorName.Contains(nameParametr)).ToList();
                        return main;
                    }
                case NameFindParamtr.Date:
                    {
                        var main = GetMainList().Where(x => x.DateStart.ToShortDateString().Contains(nameParametr)).ToList();
                        return main;
                    }
                default:
                    {
                        return null;
                    }
            }
        }

        public string CheckTime(TimeSpan timeStart, TimeSpan timeEnd)
        {
            string str = null;

            if (timeStart < timeEnd)
                str = " Time End can not biger than Time Start ";
            if (timeStart <= timeEnd + TimeSpan.FromMinutes(20))
                str = " Examination must be most 20 minites ";

            return str;
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

                DoOnAddDoctor(dr);
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

                DoOnAddPatient(pt);
            }
        }

        public void AddExamination(int doctorId, int patientId, DateTime dateStart, TimeSpan timeStart, TimeSpan timeEnd)
        {
            using (var context = new HospitalEntities())
            {
                Examination exm = new Examination();

                exm.DoctorID = doctorId;
                exm.PatientID = patientId;
                exm.DateStart = dateStart;
                exm.TimeStart = timeStart;
                exm.TimeEnd = timeEnd;

                context.Examinations.Add(exm);

                context.SaveChanges();

                DoOnAddExamination(exm);
                DoOnUpdateMainModel();
            }
        }

        public void DeleteDoctor(Doctor selectedItem)
        {
            using (var context = new HospitalEntities())
            {
                var doctor = context.Doctors.First(x => x.DoctorID == selectedItem.DoctorID);

                context.Doctors.Remove(doctor);

                context.SaveChanges();

                DoOnDeleteDoctor(doctor);
            }
        }

        public void DeletePatient(Patient selectedItem)
        {
            using (var context = new HospitalEntities())
            {
                var patient = context.Patients.First(x => x.PatientID == selectedItem.PatientID);

                context.Patients.Remove(patient);

                context.SaveChanges();

                DoOnDeletePatient(patient);
            }
        }

        public void DeleteExamination(Examination selectedItem)
        {
            using (var context = new HospitalEntities())
            {
                var examination = context.Examinations.First(x => x.PatientID == selectedItem.PatientID);

                context.Examinations.Remove(examination);

                context.SaveChanges();

                DoOnDeleteExamination(examination);
                DoOnUpdateMainModel();

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

                DoOnUpdateDoctor(doctor, selectedItem);
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

                DoOnUpdatePatient(patient, selectedItem);
            }
        }

        public void UpdateExamination(Examination selectedItem, int doctorId, int patientId, DateTime dateStart, TimeSpan timeStart, TimeSpan timeEnd)
        {
            using (var context = new HospitalEntities())
            {
                var examination = context.Examinations.First(x => x.ExaminationID == selectedItem.ExaminationID);

                examination.DoctorID = doctorId;
                examination.PatientID = patientId;
                examination.DateStart = dateStart;
                examination.TimeStart = timeStart;
                examination.TimeEnd = timeEnd;

                context.SaveChanges();

                DoOnUpdateExamination(examination, selectedItem);
                DoOnUpdateMainModel();
            }
        }

        #region Event Invoker
        protected virtual void DoOnAddDoctor(Doctor e)
        {
            OnAddDoctor?.Invoke(this, e);
        }

        protected virtual void DoOnAddPatient(Patient e)
        {
            OnAddPatient?.Invoke(this, e);
        }

        protected virtual void DoOnAddExamination(Examination e)
        {
            OnAddExamination?.Invoke(this, e);
        }

        private static void DoOnDeleteDoctor(Doctor e)
        {
            OnDeleteDoctor?.Invoke(null, e);
        }

        private static void DoOnDeletePatient(Patient e)
        {
            OnDeletePatient?.Invoke(null, e);
        }

        private static void DoOnDeleteExamination(Examination e)
        {
            OnDeleteExamination?.Invoke(null, e);
        }

        private static void DoOnUpdateDoctor(Doctor e, Doctor p)
        {
            OnUpdateDoctor?.Invoke(e, p);
        }

        private static void DoOnUpdatePatient(Patient e, Patient p)
        {
            OnUpdatePatient?.Invoke(e, p);
        }

        private static void DoOnUpdateExamination(Examination e, Examination p)
        {
            OnUpdateExamination?.Invoke(e, p);
        }

        private static void DoOnUpdateMainModel()
        {
            OnUpdateMainModel?.Invoke(null, EventArgs.Empty);
        }

        #endregion
    }
}