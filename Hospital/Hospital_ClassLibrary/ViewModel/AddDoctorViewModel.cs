using System.Windows;
using System.Windows.Input;
using Hospital_ClassLibrary.ViewModel.Command;

namespace Hospital_ClassLibrary.ViewModel
{
    public class AddDoctorViewModel
    {
        public ICommand AddDoctorCommand { get; set; }
        public ICommand ClearCommand { get; set; }


        public DataWork DWork = new DataWork();
        public string DoctorName{ get; set; }
        public string DoctorSurname { get; set; }
        public string Post { get; set; }
        public int Experience { get; set; }

        public AddDoctorViewModel()
        {
            AddDoctorCommand = new MainCommand(arg => AddDoctor());
            ClearCommand = new MainCommand(arg => Clear());
        }

        private void AddDoctor()
        {
            DWork.AddDoctor(DoctorName, DoctorSurname, Post, Experience);

            MessageBox.Show("Doctor was added !");
        }

        private void Clear()
        {
            DoctorName = " ";
            DoctorSurname = " ";
            Post = " ";
            Experience = 0;
        }
    }
}