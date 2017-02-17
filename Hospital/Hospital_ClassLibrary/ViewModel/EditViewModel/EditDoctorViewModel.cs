using System.Windows;
using System.Windows.Input;
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

        public EditDoctorViewModel(Doctor SelectedItem)
        {
            DoctorName = SelectedItem.DoctorName;
            DoctorSurname = SelectedItem.DoctorSurname;
            Post = SelectedItem.Post;
            Experience = SelectedItem.Experience;

            ClearFieldsCommand = new MainCommand(arg => ClearFields());
            EditDoctorCommand = new MainCommand(arg => EditDoctor(SelectedItem));
        }
        private void ClearFields()
        {
            DoctorName = " ";
            DoctorSurname = " ";
            Post = " ";
            Experience = 0;
        }
        private void EditDoctor(Doctor SelectedItem)
        {
            DWork.UpdateDoctor(SelectedItem, DoctorName, DoctorSurname, Post, Experience);

            MessageBox.Show("Doctor was updated !");
        }
    }
}