using System;
using System.Windows.Input;

namespace Hospital_ClassLibrary.ViewModel.Interface
{
    public interface IPatientViewModel
    {
        ICommand ClearFieldsCommand { get; set; }

        string PatientName { get; set; }

        string PatientSurname { get; set; }

        string BloodType { get; set; }

        DateTime BirthDate { get; set; }
    }
}