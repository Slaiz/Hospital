using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.Shared;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;
using PropertyChanged;

namespace Hospital_ClassLibrary.ViewModel.AddViewModel
{
    [ImplementPropertyChanged]
    public class AddExaminationViewModel : IExaminationViewModel
    {
        public ICommand OpenDoctorTableCommand { get; set; }
        public ICommand OpenPatientTableCommand { get; set; }
        public ICommand ClearFieldsCommand { get; set; }
        public ICommand AddExaminationCommand { get; set; }

        private DataWork DWork = new DataWork();

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public List<Doctor> DoctorList { get; set; }
        public List<Patient> PatientList { get; set; }

        public Func<object, TypeView, IView> CreateViewAction { get; set; }

        public AddExaminationViewModel(Func<object, TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

            DoctorList = new List<Doctor>();
            PatientList = new List<Patient>();

            foreach (var item in DWork.GetDoctorList())
            {
                DoctorList.Add(item);
            }

            foreach (var item in DWork.GetPatientList())
            {
                PatientList.Add(item);
            }

            DateStart = DateTime.Now;

            OpenDoctorTableCommand = new MainCommand(arg => OpenDoctorTable());
            OpenPatientTableCommand = new MainCommand(arg => OpenPatientTable());
            ClearFieldsCommand = new MainCommand(arg => ClearFields());
            AddExaminationCommand = new MainCommand(arg => AddExamination());
        }

        public void OpenDoctorTable()
        {
            var view = CreateViewAction(null, TypeView.DoctorView);
            view.ShowView();
        }

        public void OpenPatientTable()
        {
            var view = CreateViewAction(null, TypeView.PatientView);
            view.ShowView();
        }

        private void ClearFields()
        {
            DateStart = DateTime.Now;
            TimeStart = TimeSpan.Zero;
            TimeEnd = TimeSpan.Zero; 
        }

        private void AddExamination()
        {
            string str;
            str = DWork.CheckTime(TimeStart, TimeEnd);

            if (str == null)
            {
                DWork.AddExamination(Doctor.DoctorID, Patient.PatientID, DateStart, TimeStart, TimeEnd);
                MessageBox.Show("Examination was added !");
            }
            else MessageBox.Show(str);
        }

    }
}