using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.Shared;
using Hospital_ClassLibrary.ViewModel.Command;
using Hospital_ClassLibrary.ViewModel.Interface;
using PropertyChanged;

namespace Hospital_ClassLibrary.ViewModel.EditViewModel
{
    [ImplementPropertyChanged]
    public class EditDoctorViewModel:IDoctorViewModel
    {
        public ICommand ClearFieldsCommand { get; set; }
        public ICommand EditDoctorCommand { get; set; }

        public DataWork DWork = new DataWork();

        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string Post { get; set; }
        public int Experience { get; set; }

        public EditDoctorViewModel(Doctor selectedItem)
        {
            DoctorName = selectedItem.DoctorName;
            DoctorSurname = selectedItem.DoctorSurname;
            Post = selectedItem.Post;
            Experience = selectedItem.Experience;

            ClearFieldsCommand = new MainCommand(arg => ClearFields());
            EditDoctorCommand = new MainCommand(arg => EditDoctor(selectedItem));
        }
        private void ClearFields()
        {
            DoctorName = " ";
            DoctorSurname = " ";
            Post = " ";
            Experience = 0;
        }
        private void EditDoctor(Doctor selectedItem)
        {
            DWork.UpdateDoctor(selectedItem, DoctorName, DoctorSurname, Post, Experience);

            MessageBox.Show("Doctor was updated !");
        }
    }
}