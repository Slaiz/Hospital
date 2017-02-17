using System;
using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;
using PropertyChanged;

namespace Hospital_ClassLibrary.ViewModel.EditViewModel
{
    [ImplementPropertyChanged]
    public class EditExaminationViewModel:IExaminationViewModel
    {
        public ICommand ClearFieldsCommand { get; set; }
        public ICommand EditExaminationCommand { get; set; }

        public DataWork DWork = new DataWork();

        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime DataStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }

        public EditExaminationViewModel(Examination SelectedItem)
        {
            DoctorID = SelectedItem.DoctorID;
            PatientID = SelectedItem.PatientID;
            DataStart = SelectedItem.DataStart;
            TimeStart = SelectedItem.TimeStart;
            TimeEnd = SelectedItem.TimeEnd;

            ClearFieldsCommand = new MainCommand(arg => ClearFields());
            EditExaminationCommand = new MainCommand(arg => EditExamination(SelectedItem));
        }

        private void ClearFields()
        {
            DoctorID = 0;
            PatientID = 0;
        }

        private void EditExamination(Examination SelectedItem)
        {
            DWork.UpdateExamination(SelectedItem, DoctorID, PatientID, DataStart, TimeStart, TimeEnd);

            MessageBox.Show("Examination was updated !");
        }
    }
}