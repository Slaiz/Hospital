using System;
using System.Windows.Input;

namespace Hospital_ClassLibrary.ViewModel.Interface
{
    public interface IExaminationViewModel
    {
        ICommand ClearFieldsCommand { get; set; }

        int DoctorID { get; set; }

        int PatientID { get; set; }

        DateTime DateStart { get; set; }

        TimeSpan TimeStart { get; set; }

        TimeSpan TimeEnd { get; set; }
    }
}