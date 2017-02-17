using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.ViewModel.Command;

namespace Hospital_ClassLibrary.ViewModel.Interface
{
    public interface IDoctorViewModel
    {
        ICommand ClearFieldsCommand { get; set; }

        string DoctorName { get; set; }

        string DoctorSurname { get; set; }

        string Post { get; set; }

        int Experience { get; set; }
    }
}