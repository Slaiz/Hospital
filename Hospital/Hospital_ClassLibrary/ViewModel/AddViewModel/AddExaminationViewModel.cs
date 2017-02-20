using System;
using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;
using PropertyChanged;

namespace Hospital_ClassLibrary.ViewModel.AddViewModel
{
    [ImplementPropertyChanged]
    public class AddExaminationViewModel:IExaminationViewModel
    {
        public ICommand OpenDoctorTableCommand { get; set; }
        public ICommand OpenPatientTableCommand { get; set; }
        public ICommand ClearFieldsCommand { get; set; }
        public ICommand AddExaminationCommand { get; set; }

        private DataWork DWork = new DataWork();

        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }

        public Func<object, TypeView, IView> CreateViewAction { get; set; }

        public AddExaminationViewModel(Func<object, TypeView, IView> createViewAction)
        {
            CreateViewAction = createViewAction;

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
            DoctorID = 0;
            PatientID = 0;
        }

        private void AddExamination()
        {
            DWork.AddExamination(DoctorID, PatientID, DateStart, TimeStart, TimeEnd);

            MessageBox.Show("Examination was added !");
        }

    }
}